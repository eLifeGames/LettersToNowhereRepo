using Zenject;
using UnityEngine;

using _Root.Player.Factory;

namespace _Root.Player.Infrastructure
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Player _playerPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle().WithArguments(_playerPrefab, _playerConfig).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerEventsProvider>().AsSingle().NonLazy();
        }
    }
}