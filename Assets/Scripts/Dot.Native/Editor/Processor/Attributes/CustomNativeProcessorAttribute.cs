using System;

namespace DotEditor.Native
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomNativeProcessorAttribute : Attribute
    {
        public Type targetType { get; private set; }
        public CustomNativeProcessorAttribute(Type targetType)
        {
            this.targetType = targetType;
        }
    }
}
