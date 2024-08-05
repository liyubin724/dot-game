using DotEngine.Events;
using DotEngine.FW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.FW
{
    public class GameFacade : Facade
    {
        protected override void OnInitializeDispatcher()
        {
            var evtMgr = EventManager.GetInstance();

            base.OnInitializeDispatcher();
        }
    }
}
