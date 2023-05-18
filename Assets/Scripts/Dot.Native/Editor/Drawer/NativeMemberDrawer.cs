using DotEngine.BL;
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
        public abstract bool visible { get; }
        public abstract string label { get; }
        public abstract Type memberType { get; }

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
            memberView.name = "member-drawer-container";
            var containerView = context.containerElements.Peek();
            containerView.Add(memberView);

            context.containerElements.Push(memberView);
            {
                var controlAttrs = member.GetCustomAttributes<NativeControlAttribute>();
                if (controlAttrs != null)
                {
                    foreach (var attr in controlAttrs)
                    {
                        var processor = NativeProvider.CreateProcessor<NativeControlProcessor>(attr);
                        m_AttrProcessors.Add(processor);
                        processor.OnControl(context);
                    }
                }

                var decoratorAttrs = member.GetCustomAttributes<NativeDecoratorAttribute>();
                if (decoratorAttrs != null)
                {
                    foreach (var attr in decoratorAttrs)
                    {
                        var processor = NativeProvider.CreateProcessor<NativeDecoratorProcessor>(attr);
                        m_AttrProcessors.Add(processor);
                        processor.OnCreateGUI(context);
                    }
                }
                //var styleAttr = member.GetCustomAttribute<NativeStyleAttribute>();
                //if (styleAttr != null)
                //{
                //    var styleProcessor = NativeProvider.CreateProcessor<NativeAttrStyleProcessor>(styleAttr);
                //    m_AttrProcessors.Add(styleProcessor);
                //    styleProcessor.OnStyleGUI(this, context);
                //}
                //else
                //{
                //    var typeElement = NativeProvider.CreateElement(this);
                //    if (typeElement != null)
                //    {
                //        typeElement.OnDrawer(context);
                //    }
                //}
            }
            context.containerElements.Pop();
        }

        public virtual void OnValueChanged(object previousValue, object newValue)
        {

        }
    }
}
