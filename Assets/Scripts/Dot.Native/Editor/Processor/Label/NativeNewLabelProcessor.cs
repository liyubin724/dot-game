using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeNewLabelAttribute))]
    public class NativeNewLabelProcessor : NativeLabelProcessor
    {
        public override string GetLabel()
        {
            var labelAttr = GetAttr<NativeNewLabelAttribute>();
            return labelAttr.newLabel;
        }
    }
}
