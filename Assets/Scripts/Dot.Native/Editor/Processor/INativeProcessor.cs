using DotEngine.Native;

namespace DotEditor.Native
{
    public interface INativeProcessor
    {
        NativeMemberDrawer memberDrawer { get; set; }
    }

    public interface INativeAttrProcessor : INativeProcessor
    {
        public NativeAttribute attr { get; set; }
    }
}
