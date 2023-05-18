using DotEngine.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotEditor.Native
{
    public static class NativeProcessorProvider
    {
        private static Dictionary<Type, Type> m_AttrToProcessorDic = new Dictionary<Type, Type>();
        private static Dictionary<Type, Type> m_TypeToProcessorDic = new Dictionary<Type, Type>();
        static NativeProcessorProvider()
        {
            var processorTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(NativeProcessor))
                                  let attrProcessor = type.GetCustomAttribute<CustomNativeAttrProcessorAttribute>()
                                  let typeProcessor = type.GetCustomAttribute<CustomNativeTypeProcessorAttribute>()
                                  where attrProcessor != null || typeProcessor != null
                                  select new { type = type, typeProcessorAttr = typeProcessor, attrProcessorAttr = attrProcessor }
                                  ).ToArray();

            foreach (var processorType in processorTypes)
            {
                var type = processorType.type;
                var typeProcessorAttr = processorType.typeProcessorAttr;
                var attrProcessorAttr = processorType.attrProcessorAttr;

                if (typeProcessorAttr != null && typeProcessorAttr.valueType != null)
                {
                    m_TypeToProcessorDic.Add(typeProcessorAttr.valueType, type);
                }
                if (attrProcessorAttr != null && attrProcessorAttr.attrType != null)
                {
                    m_AttrToProcessorDic.Add(attrProcessorAttr.attrType, type);
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
            if (!m_TypeToProcessorDic.TryGetValue(memberDrawer.memberType, out var processorType))
            {
                return null;
            }

            var attrProcessor = Activator.CreateInstance(processorType) as T;
            attrProcessor.memberDrawer = memberDrawer;
            return attrProcessor;
        }
    }
}
