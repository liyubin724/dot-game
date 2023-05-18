using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeIndentAttribute))]
    public class NativeIndentProcessor : NativeControlProcessor
    {

        public override void OnControl(NativeContext context)
        {
            var indentAttr = (NativeIndentAttribute)attr;
            if (indentAttr.indent <= 0)
            {
                return;
            }

            var containerView = context.containerElements.Peek();
            containerView.style.marginLeft = indentAttr.indent * 20;
        }
    }
}
