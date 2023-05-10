using DotEngine.Avatar;
using DotEngine.UIElements;
using DotEngine.UIElements.Controls;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace DotEditor.Avatar
{
    public class AvatarNodeElement : BindableElement, INotifyValueChanged<AvatarNodeData>
    {
        private AvatarNodeData m_NodeData;

        private TextField m_AtlasNameField;
        private EnumField m_NodeTypeField;
        private ObjectField m_TransformField;
        private ObjectField m_RendererField;

        public bool showRenderField
        {
            set
            {
                m_RendererField.style.visibility = !value ? Visibility.Hidden : Visibility.Visible;
                m_RendererField.style.display = !value ? DisplayStyle.None : DisplayStyle.Flex;
            }
        }

        public AvatarNodeElement()
        {
            style.display = DisplayStyle.Flex;
            style.flexGrow = 1;

            m_AtlasNameField = new TextField("Atlas Name");
            m_AtlasNameField.RegisterValueChangedCallback((evt) =>
            {
                if (m_NodeData != null)
                {
                    m_NodeData.atlasName = evt.newValue;
                }
            });
            Add(m_AtlasNameField);

            m_NodeTypeField = new EnumField("Node Type", AvatarNodeType.None);
            m_NodeTypeField.RegisterValueChangedCallback(evt =>
            {
                if (m_NodeData != null)
                {
                    m_NodeData.nodeType = (AvatarNodeType)evt.newValue;
                }
            });
            m_NodeTypeField.SetEnabled(false);
            Add(m_NodeTypeField);

            m_TransformField = new ObjectField("Transform");
            m_TransformField.objectType = typeof(Transform);
            m_TransformField.RegisterValueChangedCallback(evt =>
            {
                if (m_NodeData != null)
                {
                    m_NodeData.transform = (Transform)evt.newValue;
                }
            });
            Add(m_TransformField);

            m_RendererField = new ObjectField("Renderer");
            m_TransformField.objectType = typeof(Renderer);
            m_TransformField.RegisterValueChangedCallback(evt =>
            {
                if (m_NodeData != null)
                {
                    m_NodeData.renderer = (Renderer)evt.newValue;
                }
            });
            Add(m_RendererField);

            var line = new SeparatorElement();
            line.orientation = Orientation.Horizontal;
            Add(line);
        }

        public AvatarNodeData value
        {
            get
            {
                return m_NodeData;
            }
            set
            {
                if (value == m_NodeData)
                {
                    return;
                }

                var prevValue = m_NodeData;
                SetValueWithoutNotify(value);

                using (var evt = ChangeEvent<AvatarNodeData>.GetPooled(prevValue, m_NodeData))
                {
                    evt.target = this;
                    SendEvent(evt);
                }
            }
        }

        public void SetValueWithoutNotify(AvatarNodeData value)
        {
            m_NodeData = value;
            if (m_NodeData == null)
            {
                m_AtlasNameField.SetValueWithoutNotify(string.Empty);
                m_NodeTypeField.SetValueWithoutNotify(AvatarNodeType.None);
                m_TransformField.SetValueWithoutNotify(null);
                m_RendererField.SetValueWithoutNotify(null);
            }
            else
            {
                m_AtlasNameField.SetValueWithoutNotify(m_NodeData.atlasName);
                m_NodeTypeField.SetValueWithoutNotify(m_NodeData.nodeType);
                m_TransformField.SetValueWithoutNotify(m_NodeData.transform);
                m_RendererField.SetValueWithoutNotify(m_NodeData.renderer);
            }
        }
    }

    class AvatarNodeListItem : VisualElement
    {
        public Label indexLabel;
        public AvatarNodeElement nodeElement;

        public AvatarNodeListItem()
        {
            style.flexDirection = FlexDirection.Row;
            style.display = DisplayStyle.Flex;
            style.flexGrow = 1;

            style.alignItems = Align.Center;

            indexLabel = new Label();
            indexLabel.style.minWidth = 20;
            indexLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
            Add(indexLabel);

            nodeElement = new AvatarNodeElement();
            Add(nodeElement);
        }
    }

    [CustomEditor(typeof(AvatarNodeBehaviour))]
    public class AvatarNodeBehaviourEditor : Editor
    {
        private AvatarNodeBehaviour m_NodeBehaviour;

        private VisualElement m_RootView;

        private ListView m_BoneListView;
        private ListView m_BindListView;
        private ListView m_RendererListView;

        private void OnEnable()
        {
            m_NodeBehaviour = target as AvatarNodeBehaviour;
        }

        public override VisualElement CreateInspectorGUI()
        {
            m_RootView = new VisualElement();

            m_BoneListView = CreateNodeListView("Bone List", AvatarNodeType.BoneNode, m_NodeBehaviour.boneNodes);
            m_RootView.Add(m_BoneListView);

            m_BindListView = CreateNodeListView("Bind List", AvatarNodeType.BindNode, m_NodeBehaviour.bindNodes);
            m_RootView.Add(m_BindListView);

            m_RendererListView = CreateNodeListView("Renderer List", AvatarNodeType.RendererNode, m_NodeBehaviour.rendererNodes, true);
            m_RootView.Add(m_RendererListView);

            return m_RootView;
        }

        private ListView CreateNodeListView(string headerTitle, AvatarNodeType nodeType, List<AvatarNodeData> datas, bool showRenderer = false)
        {
            var listView = new ListView();
            listView.itemsSource = datas;

            listView.headerTitle = headerTitle;
            listView.showFoldoutHeader = true;

            listView.showBorder = true;
            listView.reorderable = true;
            listView.reorderMode = ListViewReorderMode.Animated;

            listView.showAddRemoveFooter = true;

            listView.showBoundCollectionSize = false;
            listView.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
            listView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            listView.makeItem = () =>
            {
                return new AvatarNodeListItem();
            };
            listView.bindItem = (element, index) =>
            {
                var listItem = element as AvatarNodeListItem;
                var nodeData = datas[index];

                listItem.indexLabel.text = $"{index}";
                listItem.nodeElement.value = nodeData;
                listItem.nodeElement.showRenderField = showRenderer;
            };
            listView.itemsAdded += (indexes) =>
            {
                foreach (var index in indexes)
                {
                    if (datas[index] == null)
                    {
                        datas[index] = new AvatarNodeData();
                    }
                    datas[index].nodeType = nodeType;
                    datas[index].atlasName = $"{nodeType}-{index}";
                }
            };

            return listView;
        }

    }

}
