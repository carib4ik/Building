using BaCon.Scripts;
using Building.Scripts.Game.Gameplay.Commands;
using Building.Scripts.Game.Gameplay.Root;
using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.Settings;
using Building.Scripts.Game.State;
using Building.Scripts.Game.State.cmd;

namespace Building.Scripts.Game.Gameplay
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;
            var settingsProvider = container.Resolve<ISettingsProvider>();
            var gameSettings = settingsProvider.GameSettings;
            
            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);
            
            container.RegisterFactory(_ => 
                new BuildingsService(gameState.Buildings,gameSettings.BuildingsSettings, cmd))
                .AsSingle();
        }
    }
}