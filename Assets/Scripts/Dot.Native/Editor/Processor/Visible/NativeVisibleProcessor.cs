using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeVisibleProcessor : NativeAttrProcessor
    {
        protected NativeVisibleProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public abstract bool CalculateVisible();
    }
}
