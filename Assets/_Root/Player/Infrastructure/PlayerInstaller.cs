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

            Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _spawnPoint.position, Quaternion.identity, null);

            Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();

            /// NOTE: Вообще пока-что самый неправильный способ спавна игрока...
            /// Так-как я учусь только работать на Zenject и пока не понял еще что можно в Clean Code Arch и что нельзя.    
            /// Много вариантов было, как спавн сделать
            /// Но я не понял как работает Factory в Zenject, поэтому оставил Instantiate.
        }
    }
}