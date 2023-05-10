using System;
using UnityEngine;

namespace DotEngine.Avatar
{
    [Serializable]
    public class AvatarPrefabPartData
    {
        public string nodeName;
        public GameObject prefabAsset;
    }

    [Serializable]
    public class AvatarRendererPartData
    {
        public string nodeName;
        public string rootBoneNodeName;
        public string[] boneNodeNames = new string[0];
        public Mesh meshAsset;
        public Material[] materialAssets = new Material[0];
    }

    public class AvatarPartData : ScriptableObject
    {
        public string category;
        public AvatarRendererPartData[] rendererDatas = new AvatarRendererPartData[0];
        public AvatarPrefabPartData[] prefabDatas = new AvatarPrefabPartData[0];
    }
}
