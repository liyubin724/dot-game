using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace DotEngine.Avatar
{
    public static class AvatarUtil
    {
        public static AvatarPartInstance AssemblePart(AvatarNodeBehaviour nodeBehaviour, AvatarPartData partInfo)
        {
            if (nodeBehaviour == null || partInfo == null) return null;

            var partInstance = new AvatarPartInstance();
            partInstance.category = partInfo.category;
            partInstance.rendererInstances = new Renderer[partInfo.rendererDatas.Length];

            partInstance.prefabInstances = new GameObject[partInfo.prefabDatas.Length];
            for (int i = 0; i < partInfo.prefabDatas.Length; i++)
            {
                var prefabData = partInfo.prefabDatas[i];
                var bindNode = nodeBehaviour.GetBindNode(prefabData.nodeName);
                if (bindNode != null)
                {
                    throw new Exception($"The node({prefabData.nodeName}) is not found");
                }

                if (prefabData.prefabAsset == null)
                {
                    throw new Exception("the asset of prefab is null");
                }

                var prefabInstance = UnityObject.Instantiate(prefabData.prefabAsset);
                partInstance.prefabInstances[i] = prefabInstance;

                prefabInstance.transform.SetParent(bindNode.transform, false);
            }

            for (int i = 0; i < partInfo.rendererDatas.Length; i++)
            {
                var rendererData = partInfo.rendererDatas[i];
                var rendererNode = nodeBehaviour.GetRendererNode(rendererData.nodeName);
                if (rendererNode == null)
                {
                    throw new Exception();
                }

                var renderer = rendererNode.renderer;
                if (renderer == null)
                {
                    throw new Exception();
                }

                if (renderer is MeshRenderer meshRenderer)
                {
                    meshRenderer.sharedMaterials = rendererData.materialAssets;
                    if (renderer.TryGetComponent<MeshFilter>(out var meshFilter))
                    {
                        meshFilter.sharedMesh = rendererData.meshAsset;
                    }
                }
                else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
                {
                    skinnedMeshRenderer.sharedMaterials = rendererData.materialAssets;
                    skinnedMeshRenderer.sharedMesh = rendererData.meshAsset;

                    skinnedMeshRenderer.rootBone = nodeBehaviour.GetBoneNode(rendererData.rootBoneNodeName)?.transform;
                    skinnedMeshRenderer.bones = nodeBehaviour.GetBones(rendererData.boneNodeNames);
                }

                partInstance.rendererInstances[i] = renderer;
            }

            return partInstance;
        }

        public static void DisassemblePart(AvatarPartInstance partInstance)
        {
            if (partInstance == null) return;

            foreach (var prefab in partInstance.prefabInstances)
            {
                if (prefab == null)
                {
                    return;
                }

                if (Application.isPlaying)
                {
                    UnityObject.DestroyImmediate(prefab);
                }
                else
                {
                    UnityObject.Destroy(prefab);
                }
            }

            foreach (var renderer in partInstance.rendererInstances)
            {
                if (renderer == null)
                {
                    return;
                }

                if (renderer is MeshRenderer meshRenderer)
                {
                    meshRenderer.sharedMaterials = new Material[0];
                    if (renderer.TryGetComponent<MeshFilter>(out var meshFilter))
                    {
                        meshFilter.sharedMesh = null;
                    }
                }
                else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
                {
                    skinnedMeshRenderer.sharedMaterials = new Material[0];
                    skinnedMeshRenderer.sharedMesh = null;

                    skinnedMeshRenderer.rootBone = null;
                    skinnedMeshRenderer.bones = new Transform[0];
                }
            }
        }
    }
}
