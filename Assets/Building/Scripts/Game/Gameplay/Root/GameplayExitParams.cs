using Building.Scripts.Game.MainMenu.Root;

namespace Building.Scripts.Game.Gameplay.Root
{
    public class GameplayExitParams
    {
        public MainMenuEnterParams MainMenuEnterParams { get; }

        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams)
        {
            MainMenuEnterParams = mainMenuEnterParams;
        }

    }
}