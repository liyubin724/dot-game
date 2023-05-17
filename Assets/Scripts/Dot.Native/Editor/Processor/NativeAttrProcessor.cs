using DotEngine.Native;

namespace DotEditor.Native
{
    public abstract class NativeAttrProcessor
    {
        protected NativeAttribute attr;

        public NativeAttrProcessor(NativeAttribute attr)
        {
            this.attr = attr;
        }

        public T GetAttr<T>() where T : NativeAttribute
        {
            return (T)attr;
        }
    }
}
