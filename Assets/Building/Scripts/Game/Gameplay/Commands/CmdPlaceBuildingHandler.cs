using Building.Scripts.Game.State.cmd;
using Building.Scripts.Game.State.Entities.Buildings;
using Building.Scripts.Game.State.Root;

namespace Building.Scripts.Game.Gameplay.Commands
{
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private readonly GameStateProxy _gameStateProxy;

        public CmdPlaceBuildingHandler(GameStateProxy gameStateProxy)
        {
            _gameStateProxy = gameStateProxy;
        }
        public bool Handle(CmdPlaceBuilding command)
        {
            var entityId = _gameStateProxy.GetEntityId();
            var newBuildingEntity = new BuildingEntity
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            _gameStateProxy.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}