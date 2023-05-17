using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeReadonlyAttribute))]
    public class NativeReadonlyProcessor : NativeControlProcessor
    {
        public NativeReadonlyProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public override void OnControl(NativeContext context)
        {
            var containerView = context.containerElements.Peek();
            containerView.SetEnabled(false);
        }
    }
}
