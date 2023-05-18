using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeAttrStyleProcessor : NativeAttrProcessor
    {
        public abstract void OnStyleGUI(NativeContext context);
    }

    public abstract class NativeInnerStyleProcessor : NativeProcessor
    {
        public abstract void OnStyleGUI(NativeContext context);
    }

    public class NativeStyleNotFoundProcessor : NativeProcessor
    {

    }
}
