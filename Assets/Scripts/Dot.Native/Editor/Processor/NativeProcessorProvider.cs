using DotEngine.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotEditor.Native
{
    public static class NativeProcessorProvider
    {
        class AttrProcessorData
        {
            public Type type;
            public CustomNativeAttrProcessorAttribute attr;
        }

        class TypeProcessorData
        {
            public Type type;
            public CustomNativeTypeProcessorAttribute attr;
        }

        private static Dictionary<Type, AttrProcessorData> m_AttrToProcessorDic = new Dictionary<Type, AttrProcessorData>();
        private static Dictionary<Type, TypeProcessorData> m_TypeToProcessorDic = new Dictionary<Type, TypeProcessorData>();
        static NativeProcessorProvider()
        {
            var processorInfos = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  from type in assembly.GetTypes()
                                  where !type.IsAbstract && type.IsPublic && type.IsSubclassOf(typeof(NativeProcessor))
                                  let attrProcessor = type.GetCustomAttribute<CustomNativeAttrProcessorAttribute>()
                                  let typeProcessor = type.GetCustomAttribute<CustomNativeTypeProcessorAttribute>()
                                  where attrProcessor != null || typeProcessor != null
                                  select new { type = type, typeProcessorAttr = typeProcessor, attrProcessorAttr = attrProcessor }
                                  ).ToArray();

            foreach (var processorInfo in processorInfos)
            {
                var processorType = processorInfo.type;
                var typeProcessorAttr = processorInfo.typeProcessorAttr;
                var attrProcessorAttr = processorInfo.attrProcessorAttr;

                if (typeProcessorAttr != null && typeProcessorAttr.valueType != null)
                {
                    m_TypeToProcessorDic.Add(typeProcessorAttr.valueType, new TypeProcessorData() { type = processorType, attr = typeProcessorAttr });
                }
                if (attrProcessorAttr != null && attrProcessorAttr.attrType != null)
                {
                    m_AttrToProcessorDic.Add(attrProcessorAttr.attrType, new AttrProcessorData() { type = processorType, attr = attrProcessorAttr });
                }
            }
        }

        public static T CreateProcessor<T>(NativeMemberDrawer memberDrawer, NativeAttribute attr) where T : NativeAttrProcessor
        {
            var attrType = attr.GetType();
            if (!m_AttrToProcessorDic.TryGetValue(attrType, out var processorData))
            {
                return null;
            }

            var attrProcessor = Activator.CreateInstance(processorData.type) as T;
            attrProcessor.memberDrawer = memberDrawer;
            attrProcessor.attr = attr;

            return attrProcessor;
        }

        public static T CreateProcessor<T>(NativeMemberDrawer memberDrawer) where T : NativeInnerStyleProcessor
        {
            Type processorType = null;
            if (m_TypeToProcessorDic.TryGetValue(memberDrawer.memberType, out var processorData))
            {
                processorType = processorData.type;
            }
            if (processorType == null)
            {
                foreach (var kvp in m_TypeToProcessorDic)
                {
                    if (kvp.Value.attr.compatibleSubtype && kvp.Value.attr.valueType.IsAssignableFrom(memberDrawer.memberType))
                    {
                        processorType = kvp.Value.type;
                    }
                }
            }

            if (processorType == null)
            {
                return null;
            }

            var attrProcessor = Activator.CreateInstance(processorType) as T;
            attrProcessor.memberDrawer = memberDrawer;
            return attrProcessor;
        }
    }
}
