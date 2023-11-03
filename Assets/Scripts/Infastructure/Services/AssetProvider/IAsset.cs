using UnityEngine;

namespace Infastructure.Services.AssetProvider {
    public interface IAsset : IService {
        Object Load(string path);
    }
}