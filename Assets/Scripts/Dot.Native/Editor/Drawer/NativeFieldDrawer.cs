using DotEngine.Native;
using System;
using System.Reflection;

namespace DotEditor.Native
{
    public class NativeFieldDrawer : NativeMemberDrawer
    {
        private FieldInfo m_Field;

        public override bool visible
        {
            get
            {
                var visibleAttr = m_Field.GetCustomAttribute<NativeVisibleAttribute>();
                if (visibleAttr != null)
                {
                    var visibleProcessor = NativeProcessorProvider.CreateProcessor<NativeVisibleProcessor>(this, visibleAttr);
                    if (visibleProcessor != null)
                    {
                        return visibleProcessor.CalculateVisible();
                    }
                }

                if (m_Field.IsPublic)
                {
                    return true;
                }
                return false;
            }
        }

        public override string label
        {
            get
            {
                var labelAttr = m_Field.GetCustomAttribute<NativeLabelAttribute>();
                if (labelAttr != null)
                {
                    var labelProcessor = NativeProcessorProvider.CreateProcessor<NativeLabelProcessor>(this, labelAttr);
                    if (labelProcessor != null)
                    {
                        return labelProcessor.GetLabel();
                    }
                }

                return m_Field.Name;
            }
        }

        public override Type memberType => m_Field.FieldType;

        public NativeFieldDrawer(NativeDrawer drawer, FieldInfo fieldInfo) : base(drawer, fieldInfo)
        {
            m_Field = fieldInfo;
        }

        public override void OnValueChanged(object previousValue, object newValue)
        {
            m_Field.SetValue(drawer.data, newValue);

            base.OnValueChanged(previousValue, newValue);
        }
    }
}
