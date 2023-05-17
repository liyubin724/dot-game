using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NativeReadonlyAttribute : NativeControlAttribute
    {
        public NativeReadonlyAttribute() { }
    }
}
