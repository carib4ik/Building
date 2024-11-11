using BaCon.Scripts;
using Building.Scripts.Game.Gameplay.Root;
using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.GameRoot.Services;
using Building.Scripts.Game.State;

namespace Building.Scripts.Game.Gameplay
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(
                c.Resolve<IGameStateProvider>().GameState,
                c.Resolve<SomeCommonService>())
            ).AsSingle();
            
        }
    }
}