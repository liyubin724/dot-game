using DotEngine.Frame;

namespace Game.Startup
{
    public class StartupSystemGroup : SystemGroup
    {
        public static readonly string NAME = "StartupSystemGroup";

        public StartupSystemGroup() : base(NAME)
        {
        }

        protected override void OnInitialize()
        {

        }
    }
}
