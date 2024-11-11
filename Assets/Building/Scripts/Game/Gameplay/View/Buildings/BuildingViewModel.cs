using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.State.Entities.Buildings;

namespace Building.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingsService _buildingsService;

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            _buildingEntity = buildingEntity;
            _buildingsService = buildingsService;
        }
    }
}