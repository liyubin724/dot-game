using DotEngine.NDrawer;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class InnerData
{
    public int innerIntValue;
    public string innerStringValue;
    public float innerDoubleValue;
}

public class BaseTestData1 : ScriptableObject
{
    public bool base1BoolValue;
    public int base1IntValue;
}

public class BaseTestData2 : BaseTestData1
{
    public float base2FloatValue;
    public long base2LongValue;
}

public class TestData : BaseTestData2
{
    public bool boolValue;
    public Bounds boundsValue;
    public Color colorValue;
    public ColorWriteMask maskValue;
    public LightMode modeValue;
    public float floatValue;
    public int intValue;
    public long longValue;
    public Rect rectValue;
    public string stringValue;
    public Material matValue;
    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Vector4 vector4Value;

    public TestData scriptableObjectValue;

    [NativeIntRange(0, 100)]
    public int intRangeValue;

    public InnerData innerDataValue;

    //private string priStringValue;
}
