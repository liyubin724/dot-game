namespace DotEditor.Native
{
    public abstract class NativeDecoratorProcessor : NativeAttrProcessor
    {
        public abstract void OnCreateGUI(NativeContext context);
    }
}
