using System;
using UnityEngine;

namespace Building.Scripts.Game.State.Buildings
{
    [Serializable]
    public class BuildingEntity
    {
        public int Id;
        public string TypeId;
        public Vector3Int Position;
        public int Level;
        
    }
}