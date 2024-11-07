using Building.Scripts.Game.Gameplay.Root;
using Building.Scripts.Game.GameRoot;
using Building.Scripts.Game.MainMenu.Root.View;
using R3;
using UnityEngine;

namespace Building.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;


        public Observable<MainMenuExitParams> Run(UIRootView uiRoot, MainMenuEnterParams enterParams)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var exitSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSignalSubj);
            
            Debug.Log($"MINE MENU ENTRY POINT: Run main menu scene. Results: {enterParams?.Result}");

            var saveName = "ololo.save";
            var levelNumber = Random.Range(0, 300);

            var gameplayEnterParams = new GameplayEnterParams(saveName, levelNumber);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
            var exitToGameplaySceneSignal = exitSignalSubj.Select(_ => mainMenuExitParams);

            return exitToGameplaySceneSignal;
        }
    }
}
