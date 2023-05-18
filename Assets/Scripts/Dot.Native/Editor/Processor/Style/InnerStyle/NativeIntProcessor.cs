using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(int))]
    public class NativeIntProcessor : NativeInnerStyleProcessor
    {
        private IntegerField m_IntField;

        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            m_IntField = new IntegerField();
            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_IntField.label = memberDrawer.label;
            }
            m_IntField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });

            containerView.Add(m_IntField);
        }
    }
}
