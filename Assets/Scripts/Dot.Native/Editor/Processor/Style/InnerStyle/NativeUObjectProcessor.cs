using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeTypeProcessor(typeof(UnityEngine.Object), true)]
    public class NativeUObjectProcessor : NativeInnerStyleProcessor
    {
        private ObjectField m_ObjectField;
        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            m_ObjectField = new ObjectField();
            m_ObjectField.objectType = memberDrawer.memberType;
            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_ObjectField.label = memberDrawer.label;
            }
            m_ObjectField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });

            containerView.Add(m_ObjectField);
        }
    }
}
