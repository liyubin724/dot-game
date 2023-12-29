using DotEditor.Core.Utilities;
using DotEngine.Avatar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace DotEditor.Avatar
{
    public static class AvatarCreatorUtil
    {
        //public static GameObject CreateSkeleton(GameObject fbx, string outputAssetFolder, string fileName = null)
        //{
        //    if (fbx == null || string.IsNullOrEmpty(outputAssetFolder))
        //    {
        //        throw new ArgumentNullException();
        //    }

        //    PrefabAssetType assetType = UnityEditor.PrefabUtility.GetPrefabAssetType(fbx);
        //    if (assetType != PrefabAssetType.Model)
        //    {
        //        Debug.LogError($"AvatarCreatorUtil::CreateSkeleton->The fbx is not a model.type = {assetType}");
        //        return null;
        //    }

        //    string outputDiskFolder = PathUtility.GetDiskPath(outputAssetFolder);
        //    if (!Directory.Exists(outputDiskFolder))
        //    {
        //        var dInfo = Directory.CreateDirectory(outputDiskFolder);
        //        if (!dInfo.Exists)
        //        {
        //            Debug.LogError($"AvatarCreatorUtil::CreateSkeleton->Create folder failed.folderPath = {outputAssetFolder}");
        //            return null;
        //        }
        //    }

        //    string skeletonPrefabAssetPath = $"{outputAssetFolder}/{(string.IsNullOrEmpty(fileName) ? fbx.name + "_skeleton" : fileName)}.prefab";
        //    GameObject cachedPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(skeletonPrefabAssetPath);
        //    //NodeBehaviour cachedNodeBehaviour = cachedPrefab?.GetComponent<NodeBehaviour>();

        //}

        public static void RefreshBoneNodes(AvatarNodeBehaviour nodeBehaviour)
        {
            if (nodeBehaviour == null) return;

            var cachedBoneNodes = nodeBehaviour.boneNodes;
            var cachedBoneNodeDic = new Dictionary<Transform, AvatarNodeData>();
            if (cachedBoneNodes != null)
            {
                foreach (var cachedBoneNode in cachedBoneNodes)
                {
                    cachedBoneNodeDic.Add(cachedBoneNode.transform, cachedBoneNode);
                }
            }

            var allBoneTransforms = new List<Transform>();
            var renderers = nodeBehaviour.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            foreach (var renderer in renderers)
            {
                if (renderer.rootBone != null)
                {
                    allBoneTransforms.Add(renderer.rootBone);
                }
                if (renderer.bones != null)
                {
                    allBoneTransforms.AddRange(renderer.bones);
                }
            }

            var newBoneNodes = new List<AvatarNodeData>();
            allBoneTransforms = allBoneTransforms.Distinct().ToList();
            foreach (var boneTransform in allBoneTransforms)
            {
                if (cachedBoneNodeDic.TryGetValue(boneTransform, out var nodeData))
                {
                    newBoneNodes.Add(nodeData);
                    continue;
                }

                nodeData = new AvatarNodeData();
                nodeData.atlasName = boneTransform.name;
                nodeData.nodeType = AvatarNodeType.BoneNode;
                nodeData.transform = boneTransform;
                newBoneNodes.Add(nodeData);
            }
            nodeBehaviour.boneNodes = newBoneNodes;
        }

        public static void RefreshRendererNodes(AvatarNodeBehaviour nodeBehaviour)
        {
            if (nodeBehaviour == null)
            {
                return;
            }

            var rendererNodes = nodeBehaviour.rendererNodes;
            var rendererNodeDic = new Dictionary<Renderer, AvatarNodeData>();
            if (rendererNodes != null)
            {
                foreach (var node in rendererNodes)
                {
                    rendererNodeDic.Add(node.renderer, node);
                }
            }

            var newRendererNodes = new List<AvatarNodeData>();
            var renderers = nodeBehaviour.GetComponentsInChildren<Renderer>(true);
            foreach (var renderer in renderers)
            {
                if (rendererNodeDic.TryGetValue(renderer, out var data))
                {
                    newRendererNodes.Add(data);
                    continue;
                }

                data = new AvatarNodeData();
                data.atlasName = renderer.name;
                data.renderer = renderer;
                data.transform = renderer.transform;
                data.nodeType = AvatarNodeType.RendererNode;
                newRendererNodes.Add(data);
            }

            nodeBehaviour.rendererNodes = newRendererNodes;
        }
    }
}
