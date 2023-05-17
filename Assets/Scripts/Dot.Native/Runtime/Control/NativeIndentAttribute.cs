using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class NativeIndentAttribute : NativeControlAttribute
    {
        public int indent { get; private set; }

        public NativeIndentAttribute(int indent)
        {
            this.indent = indent;
        }
    }
}
