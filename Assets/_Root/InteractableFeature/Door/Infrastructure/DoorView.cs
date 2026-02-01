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

        public Transform Transform => transform;

        [Inject]
        private void Construct(IInputPort inputPort, RequestTransitionUseCase transitionUseCase)
        {
            _inputPort = inputPort;
            _transitionUseCase = transitionUseCase;
        }
        
        // Обработка взаимодействия с дверью с передачей события взаимодействия
        public void Interact(InteractionEvent interactionEvent)
        {
            if (interactionEvent is DoorInteractionEvent e)
                _transitionUseCase.ChangeLocationAsync().Forget();
        }
    }
}