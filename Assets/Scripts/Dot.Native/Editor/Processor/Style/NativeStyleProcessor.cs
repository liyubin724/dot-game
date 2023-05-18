using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeStyleProcessor : NativeProcessor
    {
        protected NativeStyleProcessor(NativeMemberDrawer memberDrawer) : base(memberDrawer)
        {
        }

        public abstract void OnStyleGUI(NativeContext context);
    }

    public abstract class NativeAttrStyleProcessor : NativeStyleProcessor
    {
        protected NativeAttribute attr;
        protected NativeAttrStyleProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer)
        {
            this.attr = attr;
        }

        public T GetAttr<T>() where T : NativeAttribute
        {
            return (T)attr;
        }
    }

    public abstract class NativeInnerStyleProcessor : NativeStyleProcessor
    {
        protected NativeInnerStyleProcessor(NativeMemberDrawer memberDrawer) : base(memberDrawer)
        {
        }
    }
}
