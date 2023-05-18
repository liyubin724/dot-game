using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeAttrProcessor(typeof(NativeShowAttribute))]
    public class NativeShowProcessor : NativeVisibleProcessor
    {
        public override bool CalculateVisible()
        {
            return true;
        }
    }
}
