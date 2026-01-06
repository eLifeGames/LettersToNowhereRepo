using Zenject;
using UnityEngine;
using Assets._Root.Interfaces;

namespace Assets._Root.PlayerController
{
    public class PlayerInstaller : MonoInstaller
    {
        // NOTE: Тема ебанутая, но крутая ребят.

        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            BindPlayer();
            BindPlayerInput();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
            Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _spawnPoint.position, Quaternion.identity, null);
            Container.Bind<IMovable>().FromInstance(player);
        }

        private void BindPlayerInput()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().FromNew().AsSingle();
        }
    }
}