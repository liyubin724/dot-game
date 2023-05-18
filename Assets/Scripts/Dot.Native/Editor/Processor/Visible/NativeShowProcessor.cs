using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeShowAttribute))]
    public class NativeShowProcessor : NativeVisibleProcessor
    {
        public override bool CalculateVisible()
        {
            return true;
        }
    }
}
