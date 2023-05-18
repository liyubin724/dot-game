using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeAttrProcessor(typeof(NativeIntRangeAttribute))]
    public class NativeIntRangeProcessor : NativeAttrStyleProcessor
    {
        private SliderInt m_Slider;

        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            var intRangeAttr = (NativeIntRangeAttribute)attr;
            m_Slider = new SliderInt(intRangeAttr.min, intRangeAttr.max);
            m_Slider.showInputField = true;
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
