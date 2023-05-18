using System;

namespace DotEditor.Native
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class CustomNativeTypeProcessorAttribute : Attribute
    {
        public Type valueType { get; private set; }
        public bool compatibleSubtype { get; set; }

        public CustomNativeTypeProcessorAttribute(Type valueType, bool compatibleSubtype = false)
        {
            this.valueType = valueType;
            this.compatibleSubtype = compatibleSubtype;
        }
    }
}
