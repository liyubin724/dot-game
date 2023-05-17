using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeDecoratorProcessor : NativeAttrProcessor
    {
        protected NativeDecoratorProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public abstract void OnCreateGUI(NativeContext context);
    }
}
