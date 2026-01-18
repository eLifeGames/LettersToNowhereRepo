using Zenject;
using UnityEngine;
using _Root.Player.Domain;

namespace _Root.Player.Infrastructure
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>()
                .FromInstance(_playerConfig.ToModel())
                .AsSingle()
                .NonLazy();
        }

        public override void Start()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _spawnPoint.position, Quaternion.identity, null);

            Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
        }
    }
}