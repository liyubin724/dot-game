using System;

namespace DotEditor.Native
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomNativeTypeElementAttribute : Attribute
    {
        public Type memberType { get; private set; }
        public CustomNativeTypeElementAttribute(Type memberType)
        {
            this.memberType = memberType;
        }
    }
}
