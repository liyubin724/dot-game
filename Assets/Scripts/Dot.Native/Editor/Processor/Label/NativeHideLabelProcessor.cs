using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHideLabelAttribute))]
    public class NativeHideLabelProcessor : NativeLabelProcessor
    {
        public NativeHideLabelProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override string GetLabel()
        {
            return null;
        }
    }
}
