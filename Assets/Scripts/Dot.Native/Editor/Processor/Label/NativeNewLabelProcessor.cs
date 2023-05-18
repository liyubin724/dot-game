using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeAttrProcessor(typeof(NativeNewLabelAttribute))]
    public class NativeNewLabelProcessor : NativeLabelProcessor
    {
        public override string GetLabel()
        {
            return ((NativeNewLabelAttribute)attr).newLabel;
        }
    }
}
