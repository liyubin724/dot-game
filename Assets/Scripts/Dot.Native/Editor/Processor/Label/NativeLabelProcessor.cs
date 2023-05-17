using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeLabelProcessor : NativeAttrProcessor
    {
        protected NativeLabelProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public abstract string GetLabel();
    }
}
