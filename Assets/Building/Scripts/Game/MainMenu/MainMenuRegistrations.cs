using BaCon.Scripts;
using Building.Scripts.Game.GameRoot.Services;
using Building.Scripts.Game.MainMenu.Root;
using Building.Scripts.Game.MainMenu.Services;

namespace Building.Scripts.Game.MainMenu
{
    public static class MainMenuRegistrations
    {
        public static void Register(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}