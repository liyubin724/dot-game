using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeTypeProcessor(typeof(string))]
    public class NativeStringProcessor : NativeInnerStyleProcessor
    {
        private TextField m_TextField;

        public override void OnStyleGUI(NativeContext context)
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
