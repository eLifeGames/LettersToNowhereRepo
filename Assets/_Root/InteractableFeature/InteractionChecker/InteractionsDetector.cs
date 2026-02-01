using System;
using System.Collections.Generic;
using _Root.Player.Infrastructure;
using _Root.Shared.Ports.Input;
using _Root.Shared.Ports.Interactions;
using _Root.Shared.Ports.Interactions.Events;
using _Root.Shared.Ports.MovementFeature;
using UnityEngine;
using Zenject;

namespace _Root.InteractableFeature.InteractionChecker
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InteractionsDetector : MonoBehaviour, IDisposable
    {
        private IInputPort _inputPort;
        private List<IInteractable> _interactables = new List<IInteractable>();
        
        [Inject]
        private void Construct(IInputPort port)
        {
            _inputPort = port;
            _inputPort.OnInteractionPressed += InteractWithClosest;
        }

        private void InteractWithClosest()
        {
            var interactable = GetClosestInteractable();
            
            // когда находим дверь и взаимодействуем с ней, вызываем событие о взаимодействии с дверью и передаем туда MovePort игрока
            if (interactable != null && interactable.Transform.gameObject.TryGetComponent<DoorView>(out var doorView))
            {
                doorView.Interact(new DoorInteractionEvent(gameObject.GetComponentInParent<IMovePort>()));
            }
        }

        public void Dispose()
        {
            // NOTE: Fixed
            _inputPort.OnInteractionPressed -= InteractWithClosest;
        }

        private IInteractable GetClosestInteractable()
        {
            IInteractable interactable = null;
            float closestDistance = float.MaxValue;

            var pos = transform.position;

            foreach (var i in _interactables)
            {
                var it = i;
                if (it == null || it.Transform == null)
                {
                    continue;
                }
                float dist = Vector2.Distance(pos, it.Transform.position);

                if (dist < closestDistance)
                {
                    closestDistance = dist;
                    interactable = it;
                }
            }
            return interactable;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IInteractable>(out var interactable) && !_interactables.Contains(interactable))
                _interactables.Add(interactable);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<IInteractable>(out var interactable))
                _interactables.Remove(interactable);
        }
    }
}