using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public abstract class NativeDrawer
    {
        public object data { get; private set; }
        public Type dataType => data?.GetType();

        protected NativeContext context;
        protected VisualElement rootView;

        public NativeDrawer(object data)
        {
            context = new NativeContext();

            this.data = data;
        }

        public virtual void CreateGUI(VisualElement visualElement)
        {
            context.rootView = visualElement;
            rootView = visualElement;
        }
    }
}
