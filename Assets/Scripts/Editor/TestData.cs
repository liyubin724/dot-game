using DotEngine.Native;
using UnityEngine;

public class TestData : ScriptableObject
{
    public string stringValue;
    public int intValue;
    public float floatValue;
    public bool boolValue;

    [NativeIntRange(0, 100)]
    public int intRangeValue;

    private string priStringValue;

    [NativeShow]
    private Material matValue;
}
