using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeProcessor : INativeProcessor
    {
        public NativeMemberDrawer memberDrawer { get; set; }
    }

    public abstract class NativeAttrProcessor : NativeProcessor, INativeAttrProcessor
    {
        public NativeAttribute attr { get; set; }
    }
}
