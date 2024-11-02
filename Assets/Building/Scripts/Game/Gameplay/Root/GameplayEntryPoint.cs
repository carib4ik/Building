using System;
using Building.Scripts.Game.Gameplay.Root.View;
using Building.Scripts.Game.GameRoot;
using UnityEngine;

namespace Building.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public Action GoToMainMenuSceneRequested;
        
        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;


        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToMainMenuButtonClicked += () =>
            {
                GoToMainMenuSceneRequested?.Invoke();
            };
        }
    }
}