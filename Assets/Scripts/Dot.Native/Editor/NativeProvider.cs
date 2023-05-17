using DotEngine.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotEditor.Native
{
    public static class NativeProvider
    {
        private static Dictionary<Type, Type> m_AttrToProcessorDic = new Dictionary<Type, Type>();

        private static Dictionary<Type, Type> m_TypeToElementDic = new Dictionary<Type, Type>();

        static NativeProvider()
        {
            var processorTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(NativeAttrProcessor))
                                  let attr = type.GetCustomAttribute<CustomNativeProcessorAttribute>()
                                  where attr != null
                                  select new { type = type, attr = attr }).ToArray();

            foreach (var processorType in processorTypes)
            {
                var type = processorType.type;
                var attr = processorType.attr;

                if (attr.attrType != null)
                {
                    m_AttrToProcessorDic.Add(attr.attrType, type);
                }
            }

            var typeElements = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                from type in assembly.GetTypes()
                                where !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(NativeElement))
                                let attr = type.GetCustomAttribute<CustomNativeTypeElementAttribute>()
                                select new { type = type, attr = attr }).ToArray();
            foreach (var typeElement in typeElements)
            {
                var type = typeElement.type;
                var attr = typeElement.attr;

                if (attr.memberType != null)
                {
                    m_TypeToElementDic.Add(attr.memberType, type);
                }
            }
        }

        public static NativeAttrProcessor CreateProcessor(NativeAttribute attr)
        {
            var attrType = attr.GetType();
            if (!m_AttrToProcessorDic.TryGetValue(attrType, out var processorType))
            {
                return null;
            }

            return Activator.CreateInstance(processorType, attr) as NativeAttrProcessor;
        }

        public static NativeElement CreateElement(NativeMemberDrawer memberDrawer)
        {

        }

    }
}
