using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotEditor.Native
{
    public class NativeFieldDrawer : NativeMemberDrawer
    {
        private FieldInfo m_Field;

        public NativeFieldDrawer(NativeDrawer drawer, FieldInfo fieldInfo) : base(drawer, fieldInfo)
        {
            m_Field = fieldInfo;
        }

    }
}
