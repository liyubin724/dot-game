using System;

namespace DotEditor.Native
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomNativeProcessorAttribute : Attribute
    {
        public Type attrType { get; private set; }
        public CustomNativeProcessorAttribute(Type attrType)
        {
            this.attrType = attrType;
        }
    }
}
