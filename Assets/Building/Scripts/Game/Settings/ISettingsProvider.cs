using System.Threading.Tasks;

namespace Building.Scripts.Game.Settings
{
    public interface ISettingsProvider
    {
        GameSettings GameSettings { get; }
        ApplicationSettings ApplicationSettings { get; }

        Task<GameSettings> LoadGameSettings();
    }
}