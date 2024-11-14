using System.Threading.Tasks;
using UnityEngine;

namespace Building.Scripts.Game.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        public GameSettings GameSettings => _gameSettings;
        public ApplicationSettings ApplicationSettings { get; }

        private GameSettings _gameSettings;

        public SettingsProvider()
        {
            ApplicationSettings = Resources.Load<ApplicationSettings>(nameof(ApplicationSettings));
        }
        
        public Task<GameSettings> LoadGameSettings()    
        {
            _gameSettings = Resources.Load<GameSettings>(nameof(GameSettings));

            return Task.FromResult(_gameSettings);
        }
    }
}