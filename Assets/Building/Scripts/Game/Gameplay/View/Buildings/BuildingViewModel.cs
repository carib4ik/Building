using System.Collections.Generic;
using Building.Scripts.Game.Gameplay.Services;
using Building.Scripts.Game.Settings.Gameplay.Buildings;
using Building.Scripts.Game.State.Entities.Buildings;
using R3;
using UnityEngine;

namespace Building.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        private readonly BuildingsService _buildingsService;
        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();
        
        public readonly int BuildingEntityId;
        public readonly string TypeID;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }
        
        public BuildingViewModel(
            BuildingEntityProxy buildingEntity, 
            BuildingSettings buildingSettings,
            BuildingsService buildingsService)
        {
            BuildingEntityId = buildingEntity.Id;
            _buildingEntity = buildingEntity;
            _buildingSettings = buildingSettings;
            _buildingsService = buildingsService;
            TypeID = buildingSettings.TypeId;

            foreach (var levelSettings in buildingSettings.LevelsSettings)
            {
                _levelSettingsMap[levelSettings.Level] = levelSettings;
            }
            
            Position = buildingEntity.Position;
        }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}