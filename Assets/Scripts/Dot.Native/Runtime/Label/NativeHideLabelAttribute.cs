using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class NativeHideLabelAttribute : NativeLabelAttribute
    {
    }
}
