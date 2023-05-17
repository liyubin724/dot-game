using System;

namespace DotEngine.Native
{
    public enum NativeHelpMessageType
    {
        None,
        Info,
        Warning,
        Error,
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NativeHelpAttribute : NativeDecoratorAttribute
    {
        public string message { get; private set; }
        public NativeHelpMessageType messageType { get; private set; }

        public NativeHelpAttribute(string message, NativeHelpMessageType messageType = NativeHelpMessageType.Info)
        {
            this.message = message;
            this.messageType = messageType;
        }
    }
}
