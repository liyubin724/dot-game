using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeShowAttribute))]
    public class NativeShowProcessor : NativeVisibleProcessor
    {
        public NativeShowProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public override bool CalculateVisible()
        {
            return true;
        }
    }
}
