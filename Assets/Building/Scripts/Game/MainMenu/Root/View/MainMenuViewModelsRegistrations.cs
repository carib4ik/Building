using BaCon;
using BaCon.Scripts;
using UnityEngine.PlayerLoop;

namespace Building.Scripts.Game.MainMenu.Root.View
{
    public static class MainMenuViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIMainMenuRootViewModel()).AsSingle();
        }
    }
}