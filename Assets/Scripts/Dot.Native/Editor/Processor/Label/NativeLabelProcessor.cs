namespace DotEditor.Native
{
    public interface INativeLabelProcessor : INativeAttrProcessor
    {
        string GetLabel();
    }
    public abstract class NativeLabelProcessor : NativeAttrProcessor, INativeLabelProcessor
    {
        public abstract string GetLabel();
    }
}
