using _Root.InteractableFeature.Door.Application;
using _Root.Shared.Ports.Input;
using _Root.Shared.Ports.Interactions;
using _Root.Shared.Ports.Interactions.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class DoorView : MonoBehaviour, IInteractable
    {
        private IInputPort _inputPort;
        private RequestTransitionUseCase _transitionUseCase;
        private ToggleMovementSetupUseCase _movementSetupUseCase;

        public Transform Transform => transform;

        [Inject]
        private void Construct(IInputPort inputPort, RequestTransitionUseCase transitionUseCase,  ToggleMovementSetupUseCase movementSetupUseCase)
        {
            _inputPort = inputPort;
            _transitionUseCase = transitionUseCase;
            _movementSetupUseCase = movementSetupUseCase;
        }
        
        // Обработка взаимодействия с дверью с передачей события взаимодействия
        public void Interact(InteractionEvent interactionEvent)
        {
            if (interactionEvent is DoorInteractionEvent e)
            {
                _movementSetupUseCase.ToggleMovementLock(e.MovePort);
                _transitionUseCase.ChangeLocationAsync().Forget();
            }
        }
    }
}