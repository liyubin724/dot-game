using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeVisibleProcessor : NativeAttrProcessor
    {
        public abstract bool CalculateVisible();
    }
}
