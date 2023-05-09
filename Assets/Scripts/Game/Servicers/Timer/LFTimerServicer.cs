using DotEngine.Timer;
using DotEngine.Timer.HTW;

namespace Game.Servicers
{
    public class LFTimerServicer : TimerServicer
    {
        private const float DEFAULT_INTERVAL_IN_SEC = 1f;

        protected override ITimer CreateTimer()
        {
            var htw = new HierarchicalTimerWheel(DEFAULT_INTERVAL_IN_SEC);
            htw.AppendWheel(1000, 60);
            htw.AppendWheel(1000 * 60, 60);
            htw.AppendWheel(1000 * 60 * 60, 24);
            htw.AppendWheel(1000 * 60 * 60 * 24, 300);

            return htw;
        }
    }
}
