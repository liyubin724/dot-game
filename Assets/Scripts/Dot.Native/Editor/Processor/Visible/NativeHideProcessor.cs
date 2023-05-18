using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHideAttribute))]
    public class NativeHideProcessor : NativeVisibleProcessor
    {
        public NativeHideProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override bool CalculateVisible()
        {
            return false;
        }
    }
}
