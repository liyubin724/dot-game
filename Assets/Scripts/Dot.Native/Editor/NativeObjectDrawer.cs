using System.Collections.Generic;
using System.Reflection;

namespace DotEditor.Native
{
    public class NativeObjectDrawer : NativeDrawer
    {
        private bool m_ShowFields = true;

        private List<NativeMemberDrawer> m_Members = new List<NativeMemberDrawer>();
        public NativeObjectDrawer(object data, bool showFields) : base(data)
        {
            m_ShowFields = showFields;
        }

        protected override void OnCreateGUI()
        {
            if (m_ShowFields)
            {
                CreateFields();
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
    }
}
