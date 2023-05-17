﻿using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeHelpAttribute))]
    public class NativeHelpProcessor : NativeDecoratorProcessor
    {
        public NativeHelpProcessor(NativeAttribute attr) : base(attr)
        {
        }

        public override void OnCreateGUI(NativeContext context)
        {
            var helpAttr = GetAttr<NativeHelpAttribute>();

            var help = new HelpBox(helpAttr.message, (HelpBoxMessageType)helpAttr.messageType);

            var containerView = context.containerElements.Peek();
            containerView.Add(help);
        }
    }
}