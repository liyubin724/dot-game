using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeAttrProcessor(typeof(NativeReadonlyAttribute))]
    public class NativeReadonlyProcessor : NativeControlProcessor
    {
        public override void OnControl(NativeContext context)
        {
            var containerView = context.containerElements.Peek();
            containerView.SetEnabled(false);
        }
    }
}
