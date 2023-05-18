using DotEngine.Native;

namespace DotEditor.Native
{
    public interface INativeVisibleProcessor : INativeAttrProcessor
    {
        bool CalculateVisible();
    }

    public abstract class NativeVisibleProcessor : NativeAttrProcessor, INativeVisibleProcessor
    {
        public abstract bool CalculateVisible();
    }
}
