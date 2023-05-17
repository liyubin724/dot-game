using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NativeBoxHeaderAttribute : NativeDecoratorAttribute
    {
        public string header { get; private set; }

        public NativeBoxHeaderAttribute(string header)
        {
            this.header = header;
        }
    }
}
