using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeBoxHeaderAttribute))]
    public class NativeBoxHeaderProcessor : NativeDecoratorProcessor
    {
        private NativeBoxHeaderAttribute m_BoxHeaderAttr;
        public NativeBoxHeaderProcessor(NativeAttribute attr) : base(attr)
        {
            m_BoxHeaderAttr = GetAttr<NativeBoxHeaderAttribute>();
        }

        public override void OnCreateGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            var box = new Box();
            var label = new Label();
            label.text = m_BoxHeaderAttr.header;
            box.Add(label);
            containerView.Add(box);

        }
    }
}
