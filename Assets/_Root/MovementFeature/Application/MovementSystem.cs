using _Root.Shared.Ports.Input;
using _Root.Shared.Ports.MovementFeature;
using _Root.Shared.Ports.Player;
using _Root.Shared.Ports.Player.Events;

namespace _Root.MovementFeature.Application
{
    public class MovementSystem
    {
        private readonly MovementUsecase _movementUsecase;
        private readonly IMovePort _movePort;
        private readonly IInputPort _inputPort;
        private readonly ToggleMovementLockUseCase _toggleMovementLock;

        public MovementSystem(
            MovementUsecase movementUsecase,
            IMovePort movePort,
            IInputPort inputPort,
            ToggleMovementLockUseCase toggleMovementLock,
            IPlayerEventProvider playerEventsProvider
        )
        {
            _movementUsecase = movementUsecase;
            _movePort = movePort;
            _inputPort = inputPort;
            _toggleMovementLock = toggleMovementLock;
            
            playerEventsProvider.Subscribe<PlayerSpawnEvent>(OnPlayerSpawn);
        }

        private void OnPlayerSpawn(PlayerSpawnEvent evt) =>
            ToggleMovementLock(evt.MovementLockOnSpawn);

        public void ToggleMovementLock(MovementLock movementLock)
            => _toggleMovementLock.ToggleMovementLock(movementLock);

        public void OnTick()
        {
            _movementUsecase.Handle();
            _movePort.Rotate(_inputPort.MoveInput);
        }
        
        public void OnFixedTick()
            => _movePort.Move(_inputPort.MoveInput);
    }
}