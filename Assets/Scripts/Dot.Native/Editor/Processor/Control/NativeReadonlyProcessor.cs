using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeReadonlyAttribute))]
    public class NativeReadonlyProcessor : NativeControlProcessor
    {

        public override void OnControl(NativeContext context)
        {
            var containerView = context.containerElements.Peek();
            containerView.SetEnabled(false);
        }
    }
}
