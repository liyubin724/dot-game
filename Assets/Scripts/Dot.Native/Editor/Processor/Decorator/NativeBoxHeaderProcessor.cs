using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeBoxHeaderAttribute))]
    public class NativeBoxHeaderProcessor : NativeDecoratorProcessor
    {

        public override void OnCreateGUI(NativeContext context)
        {
            var boxHeaderAttr = (NativeBoxHeaderAttribute)attr;
            var containerView = context.containerElements.Peek();

            var box = new Box();
            var label = new Label();
            label.text = boxHeaderAttr.header;
            box.Add(label);
            containerView.Add(box);

        }
    }
}
