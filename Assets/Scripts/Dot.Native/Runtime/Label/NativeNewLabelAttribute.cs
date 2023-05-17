using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NativeNewLabelAttribute : NativeLabelAttribute
    {
        public string newLabel { get; private set; }

        public NativeNewLabelAttribute(string newLabel)
        {
            this.newLabel = newLabel;
        }
    }
}
