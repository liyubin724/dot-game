using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeTypeElement(typeof(string))]
    public class NativeStringElement : NativeElement
    {
        private TextField m_TextField;
        public NativeStringElement(NativeMemberDrawer memberDrawer) : base(memberDrawer)
        {
        }

        public override void OnDrawer(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            string label = memberDrawer.label;
            m_TextField = new TextField();
            if (!string.IsNullOrEmpty(label))
            {
                m_TextField.label = label;
            }
            m_TextField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });
            containerView.Add(m_TextField);
        }
    }
}
