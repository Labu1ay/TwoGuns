using Infastructure.Services;
using Infastructure.Services.AssetProvider;
using Infastructure.Services.Input;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic {
    public class Gun : MonoBehaviour {
        private enum SelectGun {
            RIGHT_GUN = 0,
            LEFT_GUN = 1
        }
    
        [SerializeField] private Transform _spawn;
        [SerializeField] private float _bulletSpeed = 1f;
        [SerializeField] private SelectGun _selectGun;
        
        private static Bullet _bulletPrefab;
        private static ObjectPool<Bullet> _objectPool;
        private IInputService _inputService;

        private void Awake() {
            if (_bulletPrefab == null) _bulletPrefab = AllServices.Container.Single<IAsset>().Load(Path.Bullet).GetComponent<Bullet>();
            if (_objectPool == null) _objectPool = new ObjectPool<Bullet>();
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update() {
            if (_selectGun == SelectGun.LEFT_GUN) {
                if (_inputService.LeftFireButton) createBullet();
            }else if (_selectGun == SelectGun.RIGHT_GUN) {
                if (_inputService.RightFireButton) createBullet();
            }
        }
        private void createBullet() => _objectPool.Instantiate(_bulletPrefab, _spawn.position).Init(transform.forward, _bulletSpeed);
        
        private void OnDestroy() => _objectPool = null;
    }
}