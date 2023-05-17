using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public class NativeObjectDrawer : NativeDrawer
    {
        private bool m_ShowFields = true;
        private bool m_ShowProperties = false;
        private bool m_ShowMethods = false;

        private List<NativeMemberDrawer> m_Members = new List<NativeMemberDrawer>();
        public NativeObjectDrawer(object data, bool showFields, bool showProperties, bool showMethods) : base(data)
        {
            m_ShowFields = showFields;
            m_ShowProperties = showProperties;
            m_ShowMethods = showMethods;
        }

        public override void CreateGUI(VisualElement visualElement)
        {
            base.CreateGUI(visualElement);
            if (m_ShowFields)
            {
                CreateFields();
            }
            if (m_ShowProperties)
            {
                CreateProperties();
            }

            foreach (var member in m_Members)
            {
                member.CreateGUI(context);
            }
        }

        private void CreateFields()
        {
            var fieldInfos = dataType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var fieldInfo in fieldInfos)
            {
                var memeberDrawer = new NativeFieldDrawer(this, fieldInfo);
                m_Members.Add(memeberDrawer);
            }
        }

        private void CreateProperties()
        {
            var propertyInfos = dataType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var propertyInfo in propertyInfos)
            {

            }
        }

    }
}
