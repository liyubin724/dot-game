using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace DotEngine.Avatar
{
    public static class AvatarUtil
    {
        public static AvatarPartInstance AssemblePart(AvatarNodeBehaviour nodeBehaviour, AvatarPartInfo partInfo)
        {
            if (nodeBehaviour == null || partInfo == null) return null;

            var partInstance = new AvatarPartInstance();
            partInstance.category = partInfo.category;
            partInstance.rendererInstances = new Renderer[partInfo.rendererInfos.Length];

            partInstance.prefabInstances = new GameObject[partInfo.prefabInfos.Length];
            for (int i = 0; i < partInfo.prefabInfos.Length; i++)
            {
                var prefabInfo = partInfo.prefabInfos[i];
                var bindNode = nodeBehaviour.GetBindNode(prefabInfo.nodeName);
                if (bindNode != null)
                {
                    throw new Exception("The node is not found");
                }

                if (prefabInfo.prefabAsset == null)
                {
                    throw new Exception("the asset is null");
                }

                var prefabInstance = UnityObject.Instantiate(prefabInfo.prefabAsset);
                partInstance.prefabInstances[i] = prefabInstance;
            }

            for (int i = 0; i < partInfo.rendererInfos.Length; i++)
            {
                var rendererInfo = partInfo.rendererInfos[i];
                var rendererNode = nodeBehaviour.GetRendererNode(rendererInfo.nodeName);
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
                    meshRenderer.sharedMaterials = rendererInfo.materialAssets;
                    if (renderer.TryGetComponent<MeshFilter>(out var meshFilter))
                    {
                        meshFilter.sharedMesh = rendererInfo.meshAsset;
                    }
                }
                else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
                {
                    skinnedMeshRenderer.sharedMaterials = rendererInfo.materialAssets;
                    skinnedMeshRenderer.sharedMesh = rendererInfo.meshAsset;

                    skinnedMeshRenderer.rootBone = nodeBehaviour.GetBoneNode(rendererInfo.rootBoneNodeName)?.transform;
                    skinnedMeshRenderer.bones = nodeBehaviour.GetBones(rendererInfo.boneNodeNames);
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
