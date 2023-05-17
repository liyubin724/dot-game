using UnityEngine.UIElements;

namespace DotEditor.Native
{
    public abstract class NativeElement : VisualElement
    {
        protected NativeMemberDrawer memberDrawer;

        public NativeElement(NativeMemberDrawer memberDrawer)
        {
            this.memberDrawer = memberDrawer;
        }

        public abstract void OnDrawer(NativeContext context);
    }
}
