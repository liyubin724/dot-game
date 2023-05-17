using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeStyleProcessor : NativeAttrProcessor
    {
        public NativeStyleProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public abstract void OnStyleGUI(NativeMemberDrawer memberDrawer, NativeContext context);
    }
}
