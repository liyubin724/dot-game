using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeLabelProcessor : NativeAttrProcessor
    {
        protected NativeLabelProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public abstract string GetLabel();
    }
}
