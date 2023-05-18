using System;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(Enum))]
    public class NativeEnumProcessor : NativeInnerStyleProcessor
    {
        private BaseField<Enum> m_EnumField;

        public override void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            var memberType = memberDrawer.memberType;
            if (memberType.GetCustomAttribute<FlagsAttribute>() != null)
            {
                m_EnumField = new EnumFlagsField(((Enum)((NativeFieldDrawer)memberDrawer).value));
            }
            else
            {
                m_EnumField = new EnumField(((Enum)((NativeFieldDrawer)memberDrawer).value));
            }

            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                m_EnumField.label = memberDrawer.label;
            }
            m_EnumField.RegisterValueChangedCallback(evt =>
            {
                memberDrawer.OnValueChanged(evt.previousValue, evt.newValue);
            });

            containerView.Add(m_EnumField);
        }
    }
}
