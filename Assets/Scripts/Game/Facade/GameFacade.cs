using DotEngine.Core.Updater;
using DotEngine.Frame;
using Game.Init;
using Game.Startup;

namespace Game
{
    public class GameFacade : Facade
    {
        protected override void OnInitialize()
        {
            UpdateProxy.Register(Update);
        }

        protected override void OnSystemInitialize()
        {
            systemCenter.AddGroup(new InitSystemGroup());
        }

        protected override void OnDestroy()
        {
            UpdateProxy.Unregister(Update);

            base.OnDestroy();
        }
    }
}
