using System;
using System.Collections.Generic;
using Building.Scripts.Game.State.Buildings;
using UnityEngine.Serialization;

namespace Building.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        [FormerlySerializedAs("Building")] public List<BuildingEntity> Buildings;
    }
}