using DotEngine.Core.Updater;
using DotEngine.Frame;
using Game.Servicers;
using Game.Startup;

namespace Game
{
    public class GameFacade : Facade
    {
        protected override void OnServicerInitialize()
        {
            servicerCenter.Register(new HFTimerServicer());
            servicerCenter.Register(new DefaultTimerServicer());
            servicerCenter.Register(new LFTimerServicer());

            servicerCenter.Register(new PoolServicer());
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            UpdateProxy.Register(Update);
        }

        protected override void OnSystemInitialize()
        {
            systemCenter.Register<StartupSystem>();
        }

        protected override void OnDestroy()
        {
            UpdateProxy.Unregister(Update);

            base.OnDestroy();
        }
    }
}
