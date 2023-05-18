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

        private List<NativeControlProcessor> m_ControlProcessors = new List<NativeControlProcessor>();
        private List<NativeDecoratorProcessor> m_DecoratorProcessors = new List<NativeDecoratorProcessor>();
        private INativeStyleProcessor m_StyleProcessor;

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
                        var processor = NativeProcessorProvider.CreateProcessor<NativeControlProcessor>(this, attr);
                        processor.OnControl(context);
                        m_ControlProcessors.Add(processor);
                    }
                }

                var decoratorAttrs = member.GetCustomAttributes<NativeDecoratorAttribute>();
                if (decoratorAttrs != null)
                {
                    foreach (var attr in decoratorAttrs)
                    {
                        var processor = NativeProcessorProvider.CreateProcessor<NativeDecoratorProcessor>(this, attr);
                        processor.OnCreateGUI(context);
                        m_DecoratorProcessors.Add(processor);
                    }
                }
                var styleAttr = member.GetCustomAttribute<NativeStyleAttribute>();
                if (styleAttr != null)
                {
                    m_StyleProcessor = NativeProcessorProvider.CreateProcessor<NativeAttrStyleProcessor>(this, styleAttr);
                }
                else
                {
                    m_StyleProcessor = NativeProcessorProvider.CreateProcessor<NativeInnerStyleProcessor>(this);
                }

                if (m_StyleProcessor == null)
                {
                    m_StyleProcessor = new NativeStyleNotFoundProcessor();
                    m_StyleProcessor.memberDrawer = this;
                }
                m_StyleProcessor.OnStyleGUI(context);
            }
            context.containerElements.Pop();
        }

        public virtual void OnValueChanged(object previousValue, object newValue)
        {

        }
    }
}
