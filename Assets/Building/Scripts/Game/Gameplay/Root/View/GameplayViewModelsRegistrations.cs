using BaCon;
using BaCon.Scripts;
using Building.Scripts.Game.Gameplay.Services;

namespace Building.Scripts.Game.Gameplay.Root.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel(c.Resolve<SomeGameplayService>())).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel()).AsSingle();
        }
    }
}