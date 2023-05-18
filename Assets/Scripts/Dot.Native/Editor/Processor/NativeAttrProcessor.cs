using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeProcessor
    {
        public NativeMemberDrawer memberDrawer { get; set; }
    }

    public abstract class NativeAttrProcessor
    {
        public NativeMemberDrawer memberDrawer { get; set; }
        public NativeAttribute attr { get; set; }

        public T GetAttr<T>() where T : NativeAttribute
        {
            return (T)attr;
        }
    }
}
