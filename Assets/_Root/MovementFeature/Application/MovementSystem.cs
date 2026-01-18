using _Root.Shared.Ports.Input;
using _Root.Shared.Ports.MovementFeature;
using Zenject;

namespace _Root.MovementFeature.Application
{
    public class MovementSystem
    {
        private readonly MovementUsecase _movementUsecase;
        private readonly IMovePort _movePort;
        private readonly IInputPort _inputPort;

        public MovementSystem(
            MovementUsecase movementUsecase,
            IMovePort movePort,
            IInputPort inputPort
        )
        {
            _movementUsecase = movementUsecase;
            
            _movePort = movePort;
            _inputPort = inputPort;
        }

        public void OnTick()
        {
            _movementUsecase.Handle();
            
            _movePort.Rotate(_inputPort.MoveInput);
        }
        
        public void OnFixedTick()
            => _movePort.Move(_inputPort.MoveInput);
    }
}