using DotEditor.NDrawer;
using DotEngine.NDrawer;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

    private List<int> m_Datas = new List<int>();
    private Nativelistdrawer m_listDrawer;

    private void OnEnable()
    {
        m_Data = AssetDatabase.LoadAssetAtPath<TestData>("Assets/t.asset");
        if (m_Data == null)
        {
            m_Data = ScriptableObject.CreateInstance<TestData>();
            AssetDatabase.CreateAsset(m_Data, "Assets/t.asset");
        }

        m_Datas.Add(1);
        m_Datas.Add(2);
        m_Datas.Add(3);

        var list = new List<int>();
        var memberInfos = typeof(List<int>).GetMember("get_Item", BindingFlags.Public | BindingFlags.Instance);
        foreach (var memberInfo in memberInfos)
        {
            Debug.Log(memberInfo.Name);
        }

        var array = new int[] { 1, 2, };
        var mis = array.GetType().GetMembers();
        int i = 0;
    }

    private void CreateGUI()
    {
        //m_ObjectDrawer = new NativeObjectDrawer("Test Data Value", m_Data, true);
        //m_ObjectDrawer.CreateGUI(rootVisualElement);

        m_listDrawer = new Nativelistdrawer("Data lists", m_Datas, true);
        m_listDrawer.CreateGUI(rootVisualElement);
    }
}
