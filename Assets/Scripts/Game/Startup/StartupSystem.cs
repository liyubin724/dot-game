using DotEngine.Frame;
using Game.GOPool;

namespace Game.Startup
{
    public class StartupSystem : MacroSystem
    {
        protected override void OnActivate()
        {
            Add<InitUPoolSystem>();

            base.OnActivate();
        }

        protected override void OnDeactivate()
        {
            base.OnDeactivate();

            Remove<InitUPoolSystem>();
        }
    }
}
