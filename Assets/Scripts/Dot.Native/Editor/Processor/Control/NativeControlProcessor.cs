namespace DotEditor.Native
{
    public interface INativeControlProcessor : INativeAttrProcessor
    {
        void OnControl(NativeContext context);
    }

    public abstract class NativeControlProcessor : NativeAttrProcessor, INativeControlProcessor
    {
        public abstract void OnControl(NativeContext context);
    }
}
