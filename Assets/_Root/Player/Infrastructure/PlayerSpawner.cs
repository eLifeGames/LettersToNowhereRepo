using _Root.Player.Factory;
using _Root.Shared.Ports.Player.Events;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class PlayerSpawner : MonoBehaviour
    {
        private PlayerFactory _playerFactory;
        private PlayerEventsProvider _playerEventsProvider;

        [Inject]
        private void Construct(PlayerFactory playerFactory, PlayerEventsProvider playerEventsProvider)
        {
            _playerFactory = playerFactory;
            _playerEventsProvider = playerEventsProvider;
        }

        private void Start()
        {
            // Спавнить игрока при старте
            _playerFactory.Create(transform);
            _playerEventsProvider.Raise(new PlayerSpawnEvent(transform.position)); // NOTE: Сообщаем всем, что игрок заспавнился
        }
    }
}