using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeControlProcessor : NativeAttrProcessor
    {
        protected NativeControlProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public abstract void OnControl(NativeContext context);
    }
}
