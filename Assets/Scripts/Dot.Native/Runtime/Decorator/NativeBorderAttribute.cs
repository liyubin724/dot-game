using System;
using UnityEngine;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NativeBorderAttribute : NativeDecoratorAttribute
    {
        public float width { get; set; } = 2;
        public float radius { get; set; } = 0;
        public Color color { get; set; } = Color.black;

        public NativeBorderAttribute() { }
    }
}
