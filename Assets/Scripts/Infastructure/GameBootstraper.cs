using Infastructure.Services;
using Infastructure.Services.AssetProvider;
using Infastructure.Services.Input;
using Infastructure.Services.SceneLoader;
using UnityEngine;

namespace Infastructure {
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner {
        private AllServices _services;

        private void Start() {
            _services = AllServices.Container;
            RegisterService();
            AllServices.Container.Single<ISceneLoader>().Load(Constants.GameSceneName, () => {
                Instantiate(AllServices.Container.Single<IAsset>().Load(Path.HUD));
            });
            DontDestroyOnLoad(this);
        }

        private void RegisterService() {
            _services.RegisterSingle<IInputService>(RegisterInputService());
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(this));
            _services.RegisterSingle<IAsset>(new AssetProvider());
        }
    
        private static InputService RegisterInputService() {
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.isEditor) {
                return new StandaloneInputService();
            }
            else {
                return new MobileInputService();
            }
        }
    }
}