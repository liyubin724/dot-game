using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHideAttribute))]
    public class NativeHideProcessor : NativeVisibleProcessor
    {
        public NativeHideProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public override bool CalculateVisible()
        {
            return false;
        }
    }
}
