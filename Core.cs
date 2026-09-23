using MelonLoader;

[assembly: MelonInfo(typeof(OnlineMenuBypass.Core), "OnlineMenuBypass", "1.0.0", "Jonny", null)]
[assembly: MelonGame("Monkey-With-a-Bomb", "CONVRGENCE")]

namespace OnlineMenuBypass
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}