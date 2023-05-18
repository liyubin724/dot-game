using System;

namespace DotEditor.Native
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomNativeAttrProcessorAttribute : Attribute
    {
        public Type attrType { get; private set; }
        public CustomNativeAttrProcessorAttribute(Type attrType)
        {
            this.attrType = attrType;
        }
    }
}
