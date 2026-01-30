
using _Root.Shared.Ports.Interactions.Events;
using UnityEngine;

namespace _Root.Shared.Ports.Interactions
{
    public interface IInteractable
    {
        Transform Transform { get; }
        void Interact(InteractionEvent interactionEvent);
    }
}