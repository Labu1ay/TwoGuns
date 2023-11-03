using UnityEngine;

namespace Infastructure.Services.AssetProvider {
    public class AssetProvider : IAsset {
        public Object Load(string path) => Resources.Load(path);
    }
}