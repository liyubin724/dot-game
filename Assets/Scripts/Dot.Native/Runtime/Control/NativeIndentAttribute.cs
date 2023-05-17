using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class NativeIndentAttribute : NativeAttribute
    {
        public int indent { get; private set; }

        public NativeIndentAttribute(int indent)
        {
            this.indent = indent;
        }
    }
}
