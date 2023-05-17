using System;

namespace DotEditor.Native
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomNativeInnerStyleProcessorAttribute : Attribute
    {
        public Type memberType { get; private set; }
        public CustomNativeInnerStyleProcessorAttribute(Type memberType)
        {
            this.memberType = memberType;
        }
    }
}
