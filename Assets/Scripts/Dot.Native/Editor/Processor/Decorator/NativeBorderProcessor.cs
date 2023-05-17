using DotEngine.Native;
using DotEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeBorderAttribute))]
    public class NativeBorderProcessor : NativeDecoratorProcessor
    {
        private NativeBorderAttribute m_BorderAttr;

        public NativeBorderProcessor(NativeAttribute attr) : base(attr)
        {
            m_BorderAttr = GetAttr<NativeBorderAttribute>();
        }

        public override void OnCreateGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();
            containerView.SetBorderColor(m_BorderAttr.color);
            containerView.SetBorderWidth(m_BorderAttr.width);
            containerView.SetBorderRadius(m_BorderAttr.radius);
        }
    }
}
