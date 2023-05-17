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
                                where !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(NativeInnerStyleProcessor))
                                let attr = type.GetCustomAttribute<CustomNativeInnerStyleProcessorAttribute>()
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

        public static T CreateProcessor<T>(NativeAttribute attr) where T : NativeAttrProcessor
        {
            var attrType = attr.GetType();
            if (!m_AttrToProcessorDic.TryGetValue(attrType, out var processorType))
            {
                return null;
            }

            return Activator.CreateInstance(processorType, attr) as T;
        }

        public static NativeInnerStyleProcessor CreateElement(NativeMemberDrawer memberDrawer)
        {
            var memberType = memberDrawer.memberType;
            if (!m_TypeToElementDic.TryGetValue(memberType, out var elementType))
            {
                return null;
            }

            return Activator.CreateInstance(elementType, memberDrawer) as NativeInnerStyleProcessor;
        }

    }
}
