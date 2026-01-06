using Zenject;

using System;

using UnityEngine;
using UnityEngine.InputSystem;

using Assets.Settings;
using Assets._Root.Interfaces;

namespace Assets._Root.PlayerController
{
    public class PlayerInput : IDisposable, ITickable
    {
        private readonly ProjectInputActions _inputActions;
        private readonly IMovable _movable;

        public PlayerInput(ProjectInputActions inputActions, IMovable movable)
        {
            _inputActions = inputActions;
            _movable = movable;

            _inputActions.Interactions.ObjectInteraction.performed += OnObjectInteraction;
            _inputActions.Interactions.Inventory.performed += OnInventory;
            _inputActions.Interactions.ReadLetter.performed += OnReadLetter;

            _inputActions.Enable();
        }

        public void Dispose()
        {
            _inputActions.Interactions.ObjectInteraction.performed -= OnObjectInteraction;
            _inputActions.Interactions.Inventory.performed -= OnInventory;
            _inputActions.Interactions.ReadLetter.performed -= OnReadLetter;

            _inputActions.Disable();
        }

        public void Tick()
        {
            Vector2 sideMoveValue = _inputActions.Motion.SideMove.ReadValue<Vector2>();
            sideMoveValue.x = -sideMoveValue.x;

            _movable.Move(sideMoveValue);
        }

        #region Performed Inputs
        private void OnObjectInteraction(InputAction.CallbackContext context)
        {
            Debug.Log("Player Interacted With Object");
        }
        private void OnInventory(InputAction.CallbackContext context)
        {
            Debug.Log("Player Toggle Inventory");
        }
        private void OnReadLetter(InputAction.CallbackContext context)
        {
            Debug.Log("Player choosed to read the letter");
        }
        #endregion
    }
}