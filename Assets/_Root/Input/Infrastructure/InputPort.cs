using _Root.Input.Domain;
using _Root.Shared.Ports.Input;

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Input.Infrastructure
{
    public class InputPort : IInputPort, IDisposable
    {
        private InputActions _playerInput;
        private InputActions.MotionActions _playerKeys;
        private InputActions.InteractionsActions _playerInteractKeys;

        public event Action OnInteractionPressed;

        public Vector2 MoveInput
        {
            get { return _playerKeys.Move.ReadValue<Vector2>(); }
        }

        public InputPort()
        {
            InitializeInputActions();
            HookInteractionEvents();
        }
        
        public void Dispose()
        {
            UnHookInteractionEvents();

            _playerInput.Disable();
        }

        private void InitializeInputActions()
        {
            _playerInput = new();
            _playerKeys = _playerInput.Motion;
            _playerInteractKeys = _playerInput.Interactions;
            
            _playerInput.Enable();

            Debug.Log("Input port initialized");
        }
        
        private void HookInteractionEvents()
        {
            _playerInteractKeys.ObjectInteraction.performed += OnInteractionPerfomed;
        }

        private void UnHookInteractionEvents()
        {
            _playerInteractKeys.ObjectInteraction.performed -= OnInteractionPerfomed;
        }

        private void OnInteractionPerfomed(InputAction.CallbackContext ctx)
        {
            OnInteractionPressed?.Invoke();
            Debug.Log("Interaction performed");
        }
    }
}