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
    public class InteractionsDetector : MonoBehaviour
    {
        private IInputPort _inputPort;
        private List<IInteractable>  _interactables =  new List<IInteractable>();
        
        [Inject]
        private void Construct(IInputPort port)
        {
            _inputPort = port;
            _inputPort.OnInteractionPressed += InteractWithClosest;
        }

        private void InteractWithClosest()
        {
            var interactable = GetClosestInteractable();
            
            if (interactable != null && interactable.Transform.gameObject.TryGetComponent<DoorView>(out var doorView))
            {
                doorView.Interact(new DoorInteractionEvent(gameObject.GetComponentInParent<IMovePort>()));
            }
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
            var interactable = other.gameObject.GetComponent<IInteractable>();
            if (interactable != null && !_interactables.Contains(interactable))
            {
                _interactables.Add(interactable);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var interactable = other.GetComponent<IInteractable>();
            if (interactable != null)
                _interactables.Remove(interactable);
        }
    }
}