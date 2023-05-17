using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeControlProcessor : NativeAttrProcessor
    {
        protected NativeControlProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public abstract void OnControl(NativeContext context);
    }
}
