using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeReadonlyAttribute))]
    public class NativeReadonlyProcessor : NativeControlProcessor
    {
        public NativeReadonlyProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override void OnControl(NativeContext context)
        {
            var containerView = context.containerElements.Peek();
            containerView.SetEnabled(false);
        }
    }
}
