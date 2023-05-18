using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeIntRangeAttribute))]
    public class NativeIntRangeProcessor : NativeAttrStyleProcessor
    {
        private SliderInt m_Slider;

        public NativeIntRangeProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            var intRangeAttr = GetAttr<NativeIntRangeAttribute>();
            m_Slider = new SliderInt();
            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_Slider.label = memberDrawer.label;
            }
            m_Slider.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });
            containerView.Add(m_Slider);
        }

    }
}
