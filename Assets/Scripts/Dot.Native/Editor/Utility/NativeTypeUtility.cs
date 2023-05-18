using DotEngine.Core.Extensions;
using System;
using System.Collections;
using UnityEngine;

namespace DotEditor.Native
{
    static class NativeTypeUtility
    {
        public static Type GetInnerStyleType(Type type)
        {
            if (type.IsEnum)
            {
                return typeof(Enum);
            }
            if (typeof(UnityEngine.Object).IsAssignableFrom(type))
            {
                return typeof(UnityEngine.Object);
            }
            return type;
        }

        public static Type[] GetAllBaseTypes(Type type)
        {
            if (type.IsValueType)
            {
                return new Type[] { type };
            }
            if (type.IsArray)
            {
                return new Type[] { type };
            }
            if (type.IsEnum)
            {
                return new Type[] { type };
            }
            if (typeof(IList).IsAssignableFrom(type))
            {
                return new Type[] { type };
            }

            Type blockType;
            if (type.IsSubclassOf(typeof(MonoBehaviour)))
            {
                blockType = typeof(MonoBehaviour);
            }
            else if (type.IsSubclassOf(typeof(ScriptableObject)))
            {
                blockType = typeof(ScriptableObject);
            }
            else if (type.IsSubclassOf(typeof(UnityEngine.Object)))
            {
                blockType = typeof(UnityEngine.Object);
            }
            else
            {
                blockType = typeof(System.Object);
            }
            return type.GetBaseTypes(blockType);
        }
    }
}
