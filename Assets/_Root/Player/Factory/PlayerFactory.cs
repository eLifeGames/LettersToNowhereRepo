using _Root.MovementFeature.Infrastructure;
using _Root.Player.Domain;
using _Root.Player.Infrastructure;
using _Root.Shared.Ports.MovementFeature;
using UnityEngine;
using Zenject;

namespace _Root.Player.Factory
{
    public class PlayerFactory : IFactory<Transform, Player.Infrastructure.Player>
    {
        private DiContainer _container;
        private PlayerConfig _playerConfig;
        private Infrastructure.Player _playerPrefab;

        public PlayerFactory(DiContainer container, PlayerConfig playerConfig, Infrastructure.Player playerPrefab)
        {
            _container = container;
            _playerConfig = playerConfig;
            _playerPrefab = playerPrefab;
        }
        
        public Infrastructure.Player Create(Transform param)
        {
            _container.Bind<PlayerModel>()
                .FromInstance(_playerConfig.ToModel())
                .AsSingle()
                .NonLazy();

            var player = _container.InstantiatePrefabForComponent<Infrastructure.Player>(_playerPrefab);
            player.transform.localPosition = param.position;
            
            _container.BindInterfacesAndSelfTo<IMovePort>().FromInstance(player.GetComponent<MovementAdapter>()).AsSingle().NonLazy();
            return player;
        }
    }
}