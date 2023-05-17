using DotEngine.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public abstract class NativeMemberDrawer
    {
        public bool visible
        {
            get
            {
                return true;
            }
        }
        public string label { get; }
        public virtual Type memberType { get; }

        protected NativeDrawer drawer;
        protected MemberInfo member;
        protected VisualElement memberView;

        private List<NativeAttrProcessor> m_AttrProcessors = new List<NativeAttrProcessor>();

        public NativeMemberDrawer(NativeDrawer drawer, MemberInfo memberInfo)
        {
            this.drawer = drawer;
            this.member = memberInfo;
        }

        public void CreateGUI(NativeContext context)
        {
            memberView = new VisualElement();
            context.containerElements.Push(memberView);
            {
                CreateControlGUI();
                CreateDecoratorGUI();
                CreateStyleGUI();
            }
            context.containerElements.Pop();
            var containerView = context.containerElements.Peek();
            containerView.Add(memberView);
        }

        protected void CreateControlGUI()
        {
            var controlAttrs = member.GetCustomAttributes<NativeControlAttribute>();

        }

        protected void CreateDecoratorGUI()
        {
            var decoratorAttrs = member.GetCustomAttributes<NativeDecoratorAttribute>();

        }

        protected virtual void CreateStyleGUI()
        {
            var styleAttr = member.GetCustomAttribute<NativeStyleAttribute>();
            if (styleAttr != null)
            {

            }
        }

        public virtual void OnValueChanged(object previousValue, object newValue)
        {

        }
    }
}
