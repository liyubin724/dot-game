using DotEngine.Native;
using DotEngine.UIElements.Controls;
using UnityEngine;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public interface INativeStyleProcessor : INativeProcessor
    {
        void OnStyleGUI(NativeContext context);
    }

    public abstract class NativeAttrStyleProcessor : NativeAttrProcessor, INativeStyleProcessor
    {
        public abstract void OnStyleGUI(NativeContext context);
    }

    public abstract class NativeInnerStyleProcessor : NativeProcessor, INativeStyleProcessor
    {
        public abstract void OnStyleGUI(NativeContext context);
    }

    public class NativeStyleNotFoundProcessor : NativeProcessor, INativeStyleProcessor
    {
        public void OnStyleGUI(NativeContext context)
        {
            var containerView = context.containerElements.Peek();

            var messageLabel = new Label();
            messageLabel.style.color = Color.red;
            messageLabel.text = $"The style(${memberDrawer.memberType}) is not found";

            if (!string.IsNullOrEmpty(memberDrawer.label))
            {
                var label = new Label(memberDrawer.label);

                HorizontalLayout hLayout = new HorizontalLayout();
                hLayout.Add(label);
                hLayout.Add(messageLabel);

                containerView.Add(hLayout);
            }
            else
            {
                containerView.Add(messageLabel);
            }
        }
    }
}
