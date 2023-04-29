using DotEngine.Core;
using DotEngine.Core.Updater;
using DotEngine.Frame;
using UnityEngine;

namespace Game
{
    public class GameLauncher : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyHelper.Create();
            DontDestroyHelper.AddGameObject(gameObject);

            Facade.CreateInstance(() => new GameFacade());
            UpdateProxy.Register(OnUpdate);
        }

        private void OnUpdate(float deltaTime, float unscaleDeltaTime)
        {
            Facade.GetInstance().Update(deltaTime, unscaleDeltaTime);
        }

        private void OnDestroy()
        {
            UpdateProxy.Unregister(OnUpdate);
            Facade.DestroyInstance();
            DontDestroyHelper.Destroy();
        }
    }
}
