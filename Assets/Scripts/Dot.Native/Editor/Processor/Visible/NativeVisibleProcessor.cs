using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeVisibleProcessor : NativeAttrProcessor
    {
        protected NativeVisibleProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public abstract bool CalculateVisible();
    }
}
