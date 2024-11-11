using System;
using UnityEngine;

namespace Building.Scripts.Game.State.Entities.Buildings
{
    [Serializable]
    public class BuildingEntity : Entity
    {
        public string TypeId;
        public Vector3Int Position;
        public int Level;
        
    }
}