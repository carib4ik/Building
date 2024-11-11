using System;
using System.Collections.Generic;
using Building.Scripts.Game.State.Entities.Buildings;

namespace Building.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public List<BuildingEntity> Buildings;
    }
}