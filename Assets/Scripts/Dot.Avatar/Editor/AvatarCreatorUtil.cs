using DotEditor.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
