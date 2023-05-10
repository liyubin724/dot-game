using System;
using System.Collections.Generic;
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

    [CreateAssetMenu(fileName = "ttt", menuName = "Create/Avatar Part Data")]
    public class AvatarPartData : ScriptableObject
    {
        public string category;
        public List<AvatarRendererPartData> rendererDatas = new List<AvatarRendererPartData>();
        public List<AvatarPrefabPartData> prefabDatas = new List<AvatarPrefabPartData>();
    }
}
