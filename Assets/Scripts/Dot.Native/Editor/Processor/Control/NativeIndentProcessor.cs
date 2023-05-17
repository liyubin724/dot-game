using DotEngine.Native;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeIndentAttribute))]
    public class NativeIndentProcessor : NativeControlProcessor
    {
        private NativeIndentAttribute m_IndentAttr;

        public NativeIndentProcessor(NativeAttribute attr) : base(attr)
        {
            m_IndentAttr = GetAttr<NativeIndentAttribute>();
        }

        public override void OnControl(NativeContext context)
        {
            if (m_IndentAttr.indent <= 0)
            {
                return;
            }

            var containerView = context.containerElements.Peek();
            containerView.style.marginLeft = m_IndentAttr.indent * 20;
        }
    }
}
