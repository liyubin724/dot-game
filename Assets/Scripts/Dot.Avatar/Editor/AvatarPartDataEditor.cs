using DotEngine.Avatar;
using DotEngine.UIElements;
using DotEngine.UIElements.Controls;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace DotEditor.Avatar
{
    public class AvatarPrefabPartElement : BindableElement, INotifyValueChanged<AvatarPrefabPartData>
    {
        private AvatarPrefabPartData m_PartData;

        private TextField m_NodeNameField;
        private ObjectField m_PrefabAssetField;

        public AvatarPrefabPartElement()
        {
            style.display = DisplayStyle.Flex;
            style.flexGrow = 1;

            m_NodeNameField = new TextField("Node Name");
            m_NodeNameField.RegisterValueChangedCallback(evt =>
            {
                if (m_PartData != null)
                {
                    m_PartData.nodeName = evt.newValue;
                }
            });
            Add(m_NodeNameField);

            m_PrefabAssetField = new ObjectField("Prefab Asset");
            m_PrefabAssetField.objectType = typeof(GameObject);
            m_PrefabAssetField.RegisterValueChangedCallback(evt =>
            {
                if (m_PartData != null)
                {
                    m_PartData.prefabAsset = (GameObject)evt.newValue;
                }
            });
            Add(m_PrefabAssetField);

            var line = new SeparatorElement();
            line.orientation = Orientation.Horizontal;
            Add(line);
        }

        public AvatarPrefabPartData value
        {
            get
            {
                return m_PartData;
            }

            set
            {
                if (m_PartData == value) return;

                var prevValue = m_PartData;
                SetValueWithoutNotify(value);

                using (var evt = ChangeEvent<AvatarPrefabPartData>.GetPooled(prevValue, m_PartData))
                {
                    evt.target = this;
                    SendEvent(evt);
                }
            }
        }

        public void SetValueWithoutNotify(AvatarPrefabPartData value)
        {
            m_PartData = value;

            if (m_PartData == null)
            {
                m_NodeNameField.SetValueWithoutNotify(string.Empty);
                m_PrefabAssetField.SetValueWithoutNotify(null);
            }
            else
            {
                m_NodeNameField.SetValueWithoutNotify(m_PartData.nodeName);
                m_PrefabAssetField.SetValueWithoutNotify(m_PartData.prefabAsset);
            }
        }
    }

    class AvatarPrefabPartListItem : VisualElement
    {
        public Label indexLabel;
        public AvatarPrefabPartElement partElement;

        public AvatarPrefabPartListItem()
        {
            style.flexDirection = FlexDirection.Row;
            style.display = DisplayStyle.Flex;
            style.flexGrow = 1;

            style.alignItems = Align.Center;

            indexLabel = new Label();
            indexLabel.style.minWidth = 20;
            indexLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
            Add(indexLabel);

            partElement = new AvatarPrefabPartElement();
            Add(partElement);
        }
    }

    public class AvatarRendererPartElement : BindableElement, INotifyValueChanged<AvatarRendererPartData>
    {
        private AvatarRendererPartData m_PartData;

        private TextField m_NodeNameField;
        private TextField m_RootBoneNodeNameField;
        private ListView m_BoneNodeNameListView;
        private ObjectField m_MeshAssetField;
        private ListView m_MaterialAssetListView;

        public AvatarRendererPartElement()
        {
            style.display = DisplayStyle.Flex;
            style.flexGrow = 1;

            m_NodeNameField = new TextField("Node Name");
            m_NodeNameField.RegisterValueChangedCallback(evt =>
            {
                if (m_PartData != null)
                {
                    m_PartData.nodeName = evt.newValue;
                }
            });
            Add(m_NodeNameField);

            m_RootBoneNodeNameField = new TextField("Root Bone");
            m_RootBoneNodeNameField.RegisterValueChangedCallback(evt =>
            {
                if (m_PartData != null)
                {
                    m_PartData.rootBoneNodeName = evt.newValue;
                }
            });
            Add(m_RootBoneNodeNameField);

            m_BoneNodeNameListView = new ListView();
            m_BoneNodeNameListView.headerTitle = "Bone Names";
            m_BoneNodeNameListView.showFoldoutHeader = true;
            m_BoneNodeNameListView.showBorder = true;
            m_BoneNodeNameListView.reorderable = true;
            m_BoneNodeNameListView.reorderMode = ListViewReorderMode.Animated;
            m_BoneNodeNameListView.showAddRemoveFooter = true;

            m_BoneNodeNameListView.showBoundCollectionSize = false;
            m_BoneNodeNameListView.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
            m_BoneNodeNameListView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            m_BoneNodeNameListView.makeItem = () =>
            {
                var textField = new TextField();
                textField.RegisterValueChangedCallback(evt =>
                {
                    var index = (int)textField.userData;
                    m_MaterialAssetListView.itemsSource[index] = evt.newValue;
                });

                return textField;
            };
            m_BoneNodeNameListView.bindItem = (element, index) =>
            {
                var listItem = element as TextField;
                listItem.userData = index;

                var itemData = (string)m_BoneNodeNameListView.itemsSource[index];
                listItem.value = itemData;
            };
            m_BoneNodeNameListView.itemsAdded += (indexes) =>
            {
                foreach (var index in indexes)
                {
                    m_BoneNodeNameListView.itemsSource[index] = string.Empty;
                }
            };
            m_BoneNodeNameListView.RefreshItems();
            Add(m_BoneNodeNameListView);

            m_MeshAssetField = new ObjectField("Mesh Asset");
            m_MeshAssetField.objectType = typeof(Mesh);
            m_MeshAssetField.RegisterValueChangedCallback(evt =>
            {
                if (m_PartData != null)
                {
                    m_PartData.meshAsset = (Mesh)evt.newValue;
                }
            });
            Add(m_MeshAssetField);

            m_MaterialAssetListView = new ListView();
            m_MaterialAssetListView.headerTitle = "Material Assets";
            m_MaterialAssetListView.showFoldoutHeader = true;
            m_MaterialAssetListView.showBorder = true;
            m_MaterialAssetListView.reorderable = true;
            m_MaterialAssetListView.reorderMode = ListViewReorderMode.Animated;
            m_MaterialAssetListView.showAddRemoveFooter = true;

            m_MaterialAssetListView.showBoundCollectionSize = false;
            m_MaterialAssetListView.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
            m_MaterialAssetListView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            m_MaterialAssetListView.makeItem = () =>
            {
                var materialField = new ObjectField();
                materialField.objectType = typeof(Material);
                materialField.RegisterValueChangedCallback(evt =>
                {
                    var index = (int)materialField.userData;
                    m_MaterialAssetListView.itemsSource[index] = evt.newValue;
                });
                return materialField;
            };
            m_MaterialAssetListView.bindItem = (element, index) =>
            {
                var listItem = element as ObjectField;
                listItem.userData = index;

                var itemData = m_MaterialAssetListView.itemsSource[index] as UnityObject;
                listItem.value = itemData;
            };
            m_MaterialAssetListView.RefreshItems();
            Add(m_MaterialAssetListView);

            var line = new SeparatorElement();
            line.orientation = Orientation.Horizontal;
            Add(line);
        }

        public AvatarRendererPartData value
        {
            get
            {
                return m_PartData;
            }

            set
            {
                if (m_PartData == value) return;

                var prevValue = m_PartData;
                SetValueWithoutNotify(value);

                using (var evt = ChangeEvent<AvatarRendererPartData>.GetPooled(prevValue, m_PartData))
                {
                    evt.target = this;
                    SendEvent(evt);
                }
            }
        }

        public void SetValueWithoutNotify(AvatarRendererPartData value)
        {
            m_PartData = value;

            if (m_PartData == null)
            {
                m_NodeNameField.SetValueWithoutNotify(string.Empty);
                m_RootBoneNodeNameField.SetValueWithoutNotify(string.Empty);
                m_BoneNodeNameListView.itemsSource = null;
                m_MeshAssetField.SetValueWithoutNotify(null);
                m_MaterialAssetListView.itemsSource = null;
            }
            else
            {
                m_NodeNameField.SetValueWithoutNotify(m_PartData.nodeName);
                m_RootBoneNodeNameField.SetValueWithoutNotify(m_PartData.rootBoneNodeName);
                m_BoneNodeNameListView.itemsSource = m_PartData.boneNodeNames;
                m_MeshAssetField.SetValueWithoutNotify(null);
                m_MaterialAssetListView.itemsSource = m_PartData.materialAssets;
            }
        }
    }

    class AvatarRendererPartListItem : VisualElement
    {
        public Label indexLabel;
        public AvatarRendererPartElement partElement;

        public AvatarRendererPartListItem()
        {
            style.flexDirection = FlexDirection.Row;
            style.display = DisplayStyle.Flex;
            style.flexGrow = 1;

            style.alignItems = Align.Center;

            indexLabel = new Label();
            indexLabel.style.minWidth = 20;
            indexLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
            Add(indexLabel);

            partElement = new AvatarRendererPartElement();
            Add(partElement);
        }
    }

    [CustomEditor(typeof(AvatarPartData))]
    public class AvatarPartDataEditor : Editor
    {
        private AvatarPartData m_PartData;

        private VisualElement m_RootView;
        private VisualElement m_ContentView;

        private TextField m_CategoryField;
        private ListView m_RendererPartListView;
        private ListView m_PrefabPartListView;

        private void OnEnable()
        {
            m_PartData = target as AvatarPartData;
        }

        public override VisualElement CreateInspectorGUI()
        {
            m_RootView = new VisualElement();

            var helpBox = new HelpBox("Edit the config is a dangerous operation", HelpBoxMessageType.Warning);
            m_RootView.Add(helpBox);

            var toggleField = new Toggle("Enter Editor Mode");
            toggleField.value = false;
            toggleField.RegisterValueChangedCallback(evt =>
            {
                m_ContentView.SetEnabled(evt.newValue);
            });
            m_RootView.Add(toggleField);

            m_ContentView = new VisualElement();
            m_ContentView.SetEnabled(false);
            m_RootView.Add(m_ContentView);

            m_CategoryField = new TextField("Category");
            m_CategoryField.RegisterValueChangedCallback(evt =>
            {
                if (m_PartData != null)
                {
                    m_PartData.category = evt.newValue;
                }
            });
            m_ContentView.Add(m_CategoryField);

            CreateRendererListView();
            CreatePrefabListView();

            return m_RootView;
        }

        private void CreateRendererListView()
        {
            m_RendererPartListView = new ListView();
            m_RendererPartListView.itemsSource = m_PartData.rendererDatas;

            m_RendererPartListView.headerTitle = "Render Part Datas";
            m_RendererPartListView.showFoldoutHeader = true;

            m_RendererPartListView.showBorder = true;
            m_RendererPartListView.reorderable = true;
            m_RendererPartListView.reorderMode = ListViewReorderMode.Animated;

            m_RendererPartListView.showAddRemoveFooter = true;

            m_RendererPartListView.showBoundCollectionSize = false;
            m_RendererPartListView.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
            m_RendererPartListView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            m_RendererPartListView.makeItem = () =>
            {
                return new AvatarRendererPartListItem();
            };
            m_RendererPartListView.bindItem = (element, index) =>
            {
                var listItem = element as AvatarRendererPartListItem;
                var nodeData = m_PartData.rendererDatas[index];

                listItem.indexLabel.text = $"{index}";
                listItem.partElement.value = nodeData;
            };
            m_RendererPartListView.itemsAdded += (indexes) =>
            {
                foreach (var index in indexes)
                {
                    m_PartData.rendererDatas[index] = new AvatarRendererPartData();
                }
            };
            m_ContentView.Add(m_RendererPartListView);
        }

        private void CreatePrefabListView()
        {
            m_PrefabPartListView = new ListView();
            m_PrefabPartListView.itemsSource = m_PartData.prefabDatas;

            m_PrefabPartListView.headerTitle = "Render Part Datas";
            m_PrefabPartListView.showFoldoutHeader = true;

            m_PrefabPartListView.showBorder = true;
            m_PrefabPartListView.reorderable = true;
            m_PrefabPartListView.reorderMode = ListViewReorderMode.Animated;

            m_PrefabPartListView.showAddRemoveFooter = true;

            m_PrefabPartListView.showBoundCollectionSize = false;
            m_PrefabPartListView.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
            m_PrefabPartListView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            m_PrefabPartListView.makeItem = () =>
            {
                return new AvatarPrefabPartListItem();
            };
            m_PrefabPartListView.bindItem = (element, index) =>
            {
                var listItem = element as AvatarPrefabPartListItem;
                var nodeData = m_PartData.prefabDatas[index];

                listItem.indexLabel.text = $"{index}";
                listItem.partElement.value = nodeData;
            };
            m_PrefabPartListView.itemsAdded += (indexes) =>
            {
                foreach (var index in indexes)
                {
                    m_PartData.prefabDatas[index] = new AvatarPrefabPartData();
                }
            };
            m_ContentView.Add(m_PrefabPartListView);
        }
    }
}
