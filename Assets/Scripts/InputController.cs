using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Controllers.Input
{
    public class InputController : IDisposable
    {
        private readonly NewControls _inputAcions;
        public NewControls InputActions => _inputAcions;


        public event Action<Vector2> MovementRecieved;
        public event Action MovementEnd;

        public event Action JumpStarted;

        private IDisposable _eventListener;

        public InputController()
        {
            _inputAcions = new NewControls();
            _inputAcions.Enable();
        }

        public void SubscribeEvents()
        {
            _inputAcions.Default.Movement.performed += OnMovementPerformed;
            _inputAcions.Default.Movement.canceled += OnMovementEnd;
            _inputAcions.Default.Jump.started += OnJumpStarted;
        }

        private void OnJumpStarted(InputAction.CallbackContext callbackContext) => JumpStarted?.Invoke();
        private void OnMovementPerformed(InputAction.CallbackContext callbackContext) => MovementRecieved?.Invoke(callbackContext.ReadValue<Vector2>());
        private void OnMovementEnd(InputAction.CallbackContext callbackContext) => MovementEnd?.Invoke();



        public void Dispose()
        {
            _inputAcions.Default.Movement.performed -= OnMovementPerformed;
            _inputAcions.Default.Movement.canceled -= OnMovementEnd;
        }
    }
}
