using DotEngine.Core;
using DotEngine.Frame;
using Game.Init;
using Game.Startup;
using UnityEngine;

namespace Game
{
    public class GameLauncher : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyHelper.Create();
            DontDestroyHelper.AddGameObject(gameObject);

            var facade = Facade.CreateInstance(() => new GameFacade());

        }

        private void OnDestroy()
        {
            Facade.DestroyInstance();
            DontDestroyHelper.Destroy();
        }
    }
}
