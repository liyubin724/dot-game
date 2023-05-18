using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeShowAttribute))]
    public class NativeShowProcessor : NativeVisibleProcessor
    {
        public NativeShowProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override bool CalculateVisible()
        {
            return true;
        }
    }
}
