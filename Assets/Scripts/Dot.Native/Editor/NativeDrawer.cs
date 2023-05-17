using System;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public abstract class NativeDrawer
    {
        public object data { get; private set; }
        public Type dataType => data?.GetType();

        protected NativeContext context;
        protected VisualElement containerView;

        public NativeDrawer(object data)
        {
            context = new NativeContext();

            this.data = data;
        }

        public void CreateGUI(VisualElement visualElement)
        {
            containerView = new VisualElement();
            containerView.name = "object-drawer-container";
            visualElement.Add(containerView);

            context.containerElements.Push(containerView);
            {
                OnCreateGUI();
            }
            context.containerElements.Pop();
        }

        protected abstract void OnCreateGUI();
    }
}
