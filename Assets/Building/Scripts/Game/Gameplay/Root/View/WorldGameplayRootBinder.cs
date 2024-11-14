using System.Collections.Generic;
using Building.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Building.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootBinder : MonoBehaviour
    {
        // [SerializeField] private BuildingBinder _prefabBuilding;

        private readonly Dictionary<int, BuildingBinder> _createdBuildingsMap = new();
        private readonly CompositeDisposable _disposables = new();
        
        public void Bind(WorldGameplayRootViewModel viewModel)
        {
            foreach (var buildingViewModel in viewModel.AllBuildings)
            {
                CreateBuilding(buildingViewModel);
            }
            
            _disposables.Add(viewModel.AllBuildings.ObserveAdd()
                .Subscribe(e => CreateBuilding(e.Value)));
            
            _disposables.Add(viewModel.AllBuildings.ObserveRemove()
                .Subscribe(e => DestroyBuilding(e.Value)));
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        private void CreateBuilding(BuildingViewModel buildingViewModel)
        {
            var buildingLevel = Random.Range(1, 4);
            var buildingTypeID = buildingViewModel.TypeID;
            var prefabBuildingLevelPath = $"Prefabs/Gameplay/Buildings/Building_{buildingTypeID}_{buildingLevel}";
            var buildingPrefab = Resources.Load<BuildingBinder>(prefabBuildingLevelPath);
            var createdBuilding = Instantiate(buildingPrefab);
            createdBuilding.Bind(buildingViewModel);

            _createdBuildingsMap[buildingViewModel.BuildingEntityId] = createdBuilding;
        }

        private void DestroyBuilding(BuildingViewModel buildingViewModel)
        {
            if (_createdBuildingsMap.TryGetValue(buildingViewModel.BuildingEntityId, out var buildingBinder))
            {
                Destroy(buildingBinder.gameObject);
                _createdBuildingsMap.Remove(buildingViewModel.BuildingEntityId);
            }
        }
        
    }
}