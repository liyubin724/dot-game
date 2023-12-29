using System;
using System.Collections.Generic;
using UnityEngine;

namespace DotEngine.Avatar
{
    public enum AvatarNodeType
    {
        None = 0,

        BindNode,
        BoneNode,
        RendererNode,
    }

    [Serializable]
    public class AvatarNodeData
    {
        public string atlasName;
        public AvatarNodeType nodeType = AvatarNodeType.None;
        public Transform transform;
        public Renderer renderer;
    }

    public class AvatarNodeBehaviour : MonoBehaviour
    {
        public List<AvatarNodeData> boneNodes = new List<AvatarNodeData>();
        public List<AvatarNodeData> bindNodes = new List<AvatarNodeData>();
        public List<AvatarNodeData> rendererNodes = new List<AvatarNodeData>();

        private Dictionary<AvatarNodeType, Dictionary<string, AvatarNodeData>> m_NodeDic = null;

        public AvatarNodeData GetNode(AvatarNodeType type, string name)
        {
            if (m_NodeDic == null)
            {
                InitNodes();
            }

            if (m_NodeDic.TryGetValue(type, out var nodeDic))
            {
                if (nodeDic.TryGetValue(name, out var node))
                {
                    return node;
                }
            }

            return null;
        }

        public AvatarNodeData GetBoneNode(string name)
        {
            return GetNode(AvatarNodeType.BoneNode, name);
        }

        public AvatarNodeData GetBindNode(string name)
        {
            return GetNode(AvatarNodeType.BindNode, name);
        }

        public AvatarNodeData GetRendererNode(string name)
        {
            return GetNode(AvatarNodeType.RendererNode, name);
        }

        public Transform[] GetBones(string[] names)
        {
            if (names == null || names.Length == 0)
            {
                return new Transform[0];
            }

            var transforms = new Transform[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                transforms[i] = GetBoneNode(names[i])?.transform;
            }
            return transforms;
        }

        private void InitNodes()
        {
            m_NodeDic = new Dictionary<AvatarNodeType, Dictionary<string, AvatarNodeData>>();

            var nodeDic = new Dictionary<string, AvatarNodeData>();
            m_NodeDic.Add(AvatarNodeType.BoneNode, nodeDic);
            foreach (var node in boneNodes)
            {
                nodeDic.Add(node.atlasName, node);
            }

            nodeDic = new Dictionary<string, AvatarNodeData>();
            m_NodeDic.Add(AvatarNodeType.BindNode, nodeDic);
            foreach (var node in bindNodes)
            {
                nodeDic.Add(node.atlasName, node);
            }

            nodeDic = new Dictionary<string, AvatarNodeData>();
            m_NodeDic.Add(AvatarNodeType.RendererNode, nodeDic);
            foreach (var node in rendererNodes)
            {
                nodeDic.Add(node.atlasName, node);
            }
        }
    }

}

