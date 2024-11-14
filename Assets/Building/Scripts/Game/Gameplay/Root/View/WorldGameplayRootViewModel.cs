using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;

namespace Building.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(BuildingsService buildings)
        {
            AllBuildings = buildings.AllBuildings;
        }
    }
}