using System;
using Building.Scripts.Game.GameRoot;
using Building.Scripts.Game.MainMenu.Root.View;
using UnityEngine;

namespace Building.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        public Action GoToGameplaySceneRequested;
        
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;


        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToGameplayButtonClicked += () =>
            {
                GoToGameplaySceneRequested?.Invoke();
            };
        }
    }
}
