using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeDecoratorProcessor : NativeAttrProcessor
    {
        protected NativeDecoratorProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public abstract void OnCreateGUI(NativeContext context);
    }
}
