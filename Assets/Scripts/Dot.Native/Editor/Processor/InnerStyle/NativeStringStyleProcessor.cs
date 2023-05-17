using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeInnerStyleProcessor(typeof(string))]
    public class NativeStringStyleProcessor : NativeInnerStyleProcessor
    {
        private TextField m_TextField;

        public NativeStringStyleProcessor(NativeMemberDrawer memberDrawer) : base(memberDrawer)
        {
        }

        public override void OnDrawer(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            m_TextField = new TextField();
            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_TextField.label = memberDrawer.label;
            }
            m_TextField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });
            containerView.Add(m_TextField);
        }
    }
}
