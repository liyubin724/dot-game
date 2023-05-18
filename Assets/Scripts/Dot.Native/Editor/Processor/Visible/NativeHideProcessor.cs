using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeAttrProcessor(typeof(NativeHideAttribute))]
    public class NativeHideProcessor : NativeVisibleProcessor
    {
        public override bool CalculateVisible()
        {
            return false;
        }
    }
}
