using System.Collections.Generic;
using UnityEngine;

namespace Building.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingSettings", menuName = "Game Settings/Buildings/New Building Settings")]
    public class BuildingSettings : ScriptableObject
    {
        public string TypeId;
        public string TitleId;
        public string DescriptionId;
        public List<BuildingLevelSettings> LevelsSettings;
    }
}