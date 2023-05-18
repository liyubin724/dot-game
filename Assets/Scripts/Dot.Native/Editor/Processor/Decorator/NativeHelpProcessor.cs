using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHelpAttribute))]
    public class NativeHelpProcessor : NativeDecoratorProcessor
    {
        public override void OnCreateGUI(NativeContext context)
        {
            var helpAttr = (NativeHelpAttribute)attr;

            var help = new HelpBox(helpAttr.message, (HelpBoxMessageType)helpAttr.messageType);

            var containerView = context.containerElements.Peek();
            containerView.Add(help);
        }
    }
}
