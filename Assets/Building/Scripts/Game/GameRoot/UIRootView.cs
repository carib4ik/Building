using UnityEngine;

namespace Building.Scripts.Game.GameRoot
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Transform _sceneContainer;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }
        
        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }

        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneUI();
            
            sceneUI.transform.SetParent(_sceneContainer, false);
        }

        private void ClearSceneUI()
        {
            var childCount = _sceneContainer.childCount;

            for (var i = 0; i < childCount; i++)
            {
                Destroy(_sceneContainer.GetChild(i).gameObject);
            }
        }
    }
}