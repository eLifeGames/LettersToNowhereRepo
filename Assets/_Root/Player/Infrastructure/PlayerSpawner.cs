using _Root.Player.Factory;
using _Root.Shared.Ports.MovementFeature;
using _Root.Shared.Ports.Player;
using _Root.Shared.Ports.Player.Events;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private MovementLock _movementLockOnSpawn = MovementLock.AllDirection;
        
        private PlayerFactory _playerFactory;
        private IPlayerEventProvider _playerEventsProvider;

        [Inject]
        private void Construct(PlayerFactory playerFactory, IPlayerEventProvider playerEventsProvider)
        {
            _playerFactory = playerFactory;
            _playerEventsProvider = playerEventsProvider;
        }

        private void Start()
        {
            // Спавнить игрока при старте
            _playerFactory.Create(transform);
            _playerEventsProvider.Raise(new PlayerSpawnEvent(_movementLockOnSpawn)); // NOTE: Сообщаем всем, что игрок заспавнился
        }
    }
}