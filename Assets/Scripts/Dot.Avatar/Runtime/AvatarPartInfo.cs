using System;
using UnityEngine;

namespace DotEngine.Avatar
{
    [Serializable]
    public class AvatarPrefabPartInfo
    {
        public string nodeName;
        public GameObject prefabAsset;
    }

    [Serializable]
    public class AvatarRendererPartInfo
    {
        public string nodeName;
        public string rootBoneNodeName;
        public string[] boneNodeNames = new string[0];
        public Mesh meshAsset;
        public Material[] materialAssets = new Material[0];
    }

    public class AvatarPartInfo : ScriptableObject
    {
        public string category;
        public AvatarRendererPartInfo[] rendererInfos = new AvatarRendererPartInfo[0];
        public AvatarPrefabPartInfo[] prefabInfos = new AvatarPrefabPartInfo[0];
    }
}
