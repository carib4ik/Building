using BaCon.Scripts;
using Building.Scripts.Game.Gameplay.Root.View;
using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.GameRoot;
using Building.Scripts.Game.MainMenu.Root;
using Building.Scripts.Game.State;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Building.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;
        [SerializeField] private WorldGameplayRootBinder _worldRootBinder;


        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            var gameplayViewModelsContainer = new DIContainer(gameplayContainer);
            GameplayViewModelsRegistrations.Register(gameplayViewModelsContainer);
            
            // temp
            var gameStateProvider = gameplayContainer.Resolve<IGameStateProvider>();
            
            // temp
            gameStateProvider.GameState.Buildings.ObserveAdd().Subscribe(e =>
            {
                var building = e.Value;
                Debug.Log("Building placed. TypeId: " + building.TypeId +
                          " Id: " + building.Id +
                          ", Position: " + building.Position.Value);
            });

            var buildingsService = gameplayContainer.Resolve<BuildingsService>();
            
            buildingsService.PlaceBuilding("dummy", GetRandomPosition());
            buildingsService.PlaceBuilding("dummy", GetRandomPosition());
            buildingsService.PlaceBuilding("dummy", GetRandomPosition());
            
            //for test
            _worldRootBinder.Bind(gameplayViewModelsContainer.Resolve<WorldGameplayRootViewModel>());
            
            gameplayViewModelsContainer.Resolve<UIGameplayRootViewModel>();
            
            var uiRoot = gameplayContainer.Resolve<UIRootView>();
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSceneSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name: {enterParams.SaveFileName}, " +
                      $"level to load {enterParams.LevelNumber}");

            var mainMenuEnterParams = new MainMenuEnterParams("Fatality");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }

        private Vector3Int GetRandomPosition()
        {
            var rX = Random.Range(-10, 10);
            var rY = Random.Range(-10, 10);
            var rPosition = new Vector3Int(rX, rY, 0);

            return rPosition;
        }
    }
}