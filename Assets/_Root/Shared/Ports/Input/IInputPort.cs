
using System;
using _Root.Shared.Ports.Interactions.Events;
using UnityEngine;

namespace _Root.Shared.Ports.Input
{
    public interface IInputPort
    {
        public Vector2 MoveInput { get; }
        event Action OnInteractionPressed;
    }
}