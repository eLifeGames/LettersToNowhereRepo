using _Root.InteractableFeature.Door.Application.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class LocationLoader : ILocationLoader
    {
        private ZenjectSceneLoader _zenjectSceneLoader;
        private string _currentSceneName;

        [Inject]
        private void Construct(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }
        public async UniTask LoadLocation(string location)
        {
            _currentSceneName = SceneManager.GetActiveScene().name;
            await _zenjectSceneLoader.LoadSceneAsync(location, LoadSceneMode.Additive).ToUniTask();
            await SceneManager.UnloadSceneAsync(_currentSceneName).ToUniTask();
            await UniTask.Yield();
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(location));
            _currentSceneName = location;
            
        }
    }
}