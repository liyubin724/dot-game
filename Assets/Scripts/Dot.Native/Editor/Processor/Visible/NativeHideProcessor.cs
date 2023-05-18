using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHideAttribute))]
    public class NativeHideProcessor : NativeVisibleProcessor
    {
        public override bool CalculateVisible()
        {
            return false;
        }
    }
}
