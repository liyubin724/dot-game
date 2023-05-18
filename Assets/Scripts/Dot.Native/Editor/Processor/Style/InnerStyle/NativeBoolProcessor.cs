﻿using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(bool))]
    public class NativeBoolProcessor : NativeInnerStyleProcessor
    {
        private Toggle m_ToggleField;
        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            m_ToggleField = new Toggle();
            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_ToggleField.label = memberDrawer.label;
            }
            m_ToggleField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });

            containerView.Add(m_ToggleField);
        }
    }
}
