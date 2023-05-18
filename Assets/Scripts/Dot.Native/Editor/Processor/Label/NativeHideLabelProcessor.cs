using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeAttrProcessor(typeof(NativeHideLabelAttribute))]
    public class NativeHideLabelProcessor : NativeLabelProcessor
    {
        public override string GetLabel()
        {
            return null;
        }
    }
}
