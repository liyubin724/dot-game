using System;

namespace DotEngine.Native
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class NativeIntRangeAttribute : NativeStyleAttribute
    {
        public int min { get; private set; }
        public int max { get; private set; }
        public NativeIntRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
