using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotEditor.Native
{
    public class NativePropertyDrawer : NativeMemberDrawer
    {
        private PropertyInfo m_PropertyInfo;

        public NativePropertyDrawer(NativeDrawer drawer, PropertyInfo propertyInfo) : base(drawer, propertyInfo)
        {
            m_PropertyInfo = propertyInfo;
        }
    }
}
