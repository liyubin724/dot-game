﻿using DotEngine.Native;
using UnityEngine.UIElements;

namespace DotEditor.Native
{
    [CustomNativeProcessor(typeof(NativeBoxHeaderAttribute))]
    public class NativeBoxHeaderProcessor : NativeDecoratorProcessor
    {
        public NativeBoxHeaderProcessor(NativeMemberDrawer memberDrawer, NativeAttribute attr) : base(memberDrawer, attr)
        {
        }

        public override void OnCreateGUI(NativeContext context)
        {
            var boxHeaderAttr = GetAttr<NativeBoxHeaderAttribute>();
            var containerView = context.containerElements.Peek();

            var box = new Box();
            var label = new Label();
            label.text = boxHeaderAttr.header;
            box.Add(label);
            containerView.Add(box);

        }
    }
}
