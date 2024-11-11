using System;
using Building.Scripts.Game.GameRoot.Services;
using Building.Scripts.Game.State.Root;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Building.Scripts.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly SomeCommonService _someCommonService;

        public SomeGameplayService(GameStateProxy gameState, SomeCommonService someCommonService)
        {
            _someCommonService = someCommonService;
            Debug.Log(GetType().Name + " has been crated");
            
            gameState.Buildings.ForEach(b => Debug.Log($"Building: {b.TypeId}"));
            gameState.Buildings.ObserveAdd().Subscribe(e =>
                Debug.Log($"Building was added: {e.Value.TypeId}"));
            gameState.Buildings.ObserveRemove().Subscribe(e =>
                Debug.Log($"Building was removed: {e.Value.TypeId}"));
        }

        public void Dispose()
        {
            Debug.Log("Почистить все подписьки");
        }
    }
}