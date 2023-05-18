using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(float))]
    public class NativeFloatStyleProcessor : NativeInnerStyleProcessor
    {
        private FloatField m_FloatField;
        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            m_FloatField = new FloatField();
            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_FloatField.label = memberDrawer.label;
            }
            m_FloatField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });

            containerView.Add(m_FloatField);
        }
    }
}
