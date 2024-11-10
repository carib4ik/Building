using BaCon;
using BaCon.Scripts;
using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.GameRoot.Services;

namespace Building.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(c.Resolve<SomeCommonService>())).AsSingle();
            
        }
    }
}