using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeProcessor
    {
        protected NativeMemberDrawer memberDrawer;

        protected NativeProcessor(NativeMemberDrawer memberDrawer)
        {
            this.memberDrawer = memberDrawer;
        }
    }

    public abstract class NativeAttrProcessor : NativeProcessor
    {
        protected NativeAttribute attr;

        protected NativeAttrProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer)
        {
            this.attr = attr;
        }

        public T GetAttr<T>() where T : NativeAttribute
        {
            return (T)attr;
        }
    }
}
