using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeControlProcessor : NativeAttrProcessor
    {
        public abstract void OnControl(NativeContext context);
    }
}
