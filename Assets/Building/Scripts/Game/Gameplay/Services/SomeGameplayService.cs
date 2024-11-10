using System;
using Building.Scripts.Game.GameRoot.Services;
using UnityEngine;

namespace Building.Scripts.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly SomeCommonService _someCommonService;

        public SomeGameplayService(SomeCommonService someCommonService)
        {
            _someCommonService = someCommonService;
            Debug.Log(GetType().Name + " has been crated");
        }

        public void Dispose()
        {
            Debug.Log("Почистить все подписьки");
        }
    }
}