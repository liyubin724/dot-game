using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeNewLabelAttribute))]
    public class NativeNewLabelProcessor : NativeLabelProcessor
    {
        public NativeNewLabelProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override string GetLabel()
        {
            var labelAttr = GetAttr<NativeNewLabelAttribute>();
            return labelAttr.newLabel;
        }
    }
}
