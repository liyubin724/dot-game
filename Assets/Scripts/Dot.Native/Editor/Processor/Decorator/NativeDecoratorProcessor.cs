namespace DotEditor.Native
{
    public interface INativeDecoratorProcessor : INativeAttrProcessor
    {
        void OnCreateGUI(NativeContext context);
    }

    public abstract class NativeDecoratorProcessor : NativeAttrProcessor, INativeDecoratorProcessor
    {
        public abstract void OnCreateGUI(NativeContext context);
    }
}
