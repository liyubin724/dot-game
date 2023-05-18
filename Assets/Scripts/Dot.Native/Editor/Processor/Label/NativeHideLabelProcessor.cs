using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHideLabelAttribute))]
    public class NativeHideLabelProcessor : NativeLabelProcessor
    {
        public override string GetLabel()
        {
            return null;
        }
    }
}
