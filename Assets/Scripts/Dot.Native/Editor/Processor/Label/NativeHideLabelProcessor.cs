using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHideLabelAttribute))]
    public class NativeHideLabelProcessor : NativeLabelProcessor
    {
        public NativeHideLabelProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public override string GetLabel()
        {
            return null;
        }
    }
}
