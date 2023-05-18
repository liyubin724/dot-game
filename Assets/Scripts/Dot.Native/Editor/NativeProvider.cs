using DotEngine.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotEditor.Native
{
    public static class NativeProvider
    {
        private static Dictionary<Type, Type> m_AttrToProcessorDic = new Dictionary<Type, Type>();
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
        }

        public static T CreateProcessor<T>(NativeMemberDrawer memberDrawer, NativeAttribute attr) where T : NativeAttrProcessor
        {
            var attrType = attr.GetType();
            if (!m_AttrToProcessorDic.TryGetValue(attrType, out var processorType))
            {
                return null;
            }

            var attrProcessor = Activator.CreateInstance(processorType) as T;
            attrProcessor.memberDrawer = memberDrawer;
            attrProcessor.attr = attr;

            return attrProcessor;
        }

        public static T CreateProcessor<T>(NativeMemberDrawer memberDrawer) where T : NativeInnerStyleProcessor
        {
            if (!m_AttrToProcessorDic.TryGetValue(memberDrawer.memberType, out var processorType))
            {
                return null;
            }

            var attrProcessor = Activator.CreateInstance(processorType) as T;
            attrProcessor.memberDrawer = memberDrawer;
            return attrProcessor;
        }
    }
}
