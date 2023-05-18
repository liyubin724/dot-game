using DotEditor.NDrawer;
using DotEngine.NDrawer;
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

    private TestData m_Data;
    private NativeObjectDrawer m_ObjectDrawer;

    private void OnEnable()
    {
        m_Data = AssetDatabase.LoadAssetAtPath<TestData>("Assets/t.asset");
        if (m_Data == null)
        {
            m_Data = ScriptableObject.CreateInstance<TestData>();
            AssetDatabase.CreateAsset(m_Data, "Assets/t.asset");
        }
    }

    private void CreateGUI()
    {
        m_ObjectDrawer = new NativeObjectDrawer(m_Data);
        m_ObjectDrawer.showFoldoutHeader = true;
        m_ObjectDrawer.headerTitle = "Test Data Value";
        m_ObjectDrawer.CreateGUI(rootVisualElement);
    }
}
