using DotEditor.Native;
using DotEngine.Native;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestNativeDrawerWindow : EditorWindow
{
    [MenuItem("Dot Test/Test Native Drawer")]
    static void ShowWindow()
    {
        var win = GetWindow<TestNativeDrawerWindow>();
        win.titleContent = new GUIContent("Test Native Drawer");
        win.Show();
    }

    public class TestData
    {
        public string stringValue;
        public int intValue;
        public float floatValue;
        public bool boolValue;

        [NativeIntRange(0, 100)]
        public int intRangeValue;

        private string priStringValue;
    }

    private TestData m_Data = new TestData();
    private NativeObjectDrawer m_ObjectDrawer;

    private void CreateGUI()
    {
        m_ObjectDrawer = new NativeObjectDrawer(m_Data, true);
        m_ObjectDrawer.CreateGUI(rootVisualElement);
    }
}
