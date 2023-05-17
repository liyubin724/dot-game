namespace DotEditor.Native
{
    public abstract class NativeInnerStyleProcessor : NativeProcessor
    {
        protected NativeMemberDrawer memberDrawer;

        public NativeInnerStyleProcessor(NativeMemberDrawer memberDrawer)
        {
            this.memberDrawer = memberDrawer;
        }

        public abstract void OnDrawer(NativeContext context);
    }
}
