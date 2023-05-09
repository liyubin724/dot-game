using DotEngine.Core.Updater;
using DotEngine.Frame;
using DotEngine.Timer;

namespace Game.Servicers
{
    public abstract class TimerServicer : IServicer
    {
        private ITimer m_Timer;

        public void OnRegistered()
        {
            m_Timer = CreateTimer();

            UpdateProxy.Register(OnUpdate);
        }

        protected abstract ITimer CreateTimer();

        public void OnUnregistered()
        {
            UpdateProxy.Unregister(OnUpdate);

            m_Timer.ClearAllTimer();
            m_Timer = null;
        }

        public int AddTickTimer(TimerCallback intervalCallback, object userdata = null)
        {
            return m_Timer.AddTickTimer(intervalCallback, userdata);
        }

        public int AddIntervalTimer(float intervalInSec, TimerCallback intervalCallback, object userdata = null)
        {
            return m_Timer.AddIntervalTimer(intervalInSec, intervalCallback, userdata);
        }

        public int AddEndTimer(float totalInSec, TimerCallback endCallback, object userdata = null)
        {
            return m_Timer.AddEndTimer(totalInSec, endCallback, userdata);
        }

        public int AddTimer(float intervalInSec, float totalInSec, TimerCallback intervalCallback, TimerCallback endCallback, object userdata = null)
        {
            return m_Timer.AddTimer(intervalInSec, totalInSec, intervalCallback, endCallback, userdata);
        }

        public bool RemoveTimer(int timerId)
        {
            return m_Timer.RemoveTimer(timerId);
        }

        public void Clear()
        {
            m_Timer.ClearAllTimer();
        }

        public void Pause()
        {
            m_Timer.Pause();
        }

        public void Resume()
        {
            m_Timer.Resume();
        }

        private void OnUpdate(float deltaTime, float unscaleDeltaTime)
        {
            m_Timer?.Update(deltaTime);
        }
    }
}
