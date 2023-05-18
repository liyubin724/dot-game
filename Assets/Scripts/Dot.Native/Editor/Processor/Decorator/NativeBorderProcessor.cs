﻿using DotEngine.Native;
using DotEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeBorderAttribute))]
    public class NativeBorderProcessor : NativeDecoratorProcessor
    {
        public override void OnCreateGUI(NativeContext context)
        {
            var borderAttr = GetAttr<NativeBorderAttribute>();

            var containerView = context.containerElements.Peek();
            containerView.SetBorderColor(borderAttr.color);
            containerView.SetBorderWidth(borderAttr.width);
            containerView.SetBorderRadius(borderAttr.radius);
        }
    }
}
