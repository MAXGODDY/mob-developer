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
        public event Action Started;
        public event Action Setings;



        public InputController()
        {
            _inputAcions = new NewControls();

            // вместо ручного Enable() сразу переключаемся в Меню
            SwitchToMenu();
        }

        public void SwitchToMenu()
        {
            _inputAcions.Default.Movement.Disable();
            _inputAcions.Default.Jump.Disable();
            _inputAcions.Default.Start.Enable();
            _inputAcions.Default.Setings.Enable();
        }

        public void SwitchToGameplay()
        {
            _inputAcions.Default.Start.Disable();
            _inputAcions.Default.Setings.Disable();
            _inputAcions.Default.Movement.Enable();
            _inputAcions.Default.Jump.Enable();
        }

        public void SubscribeEvents()
        {
            _inputAcions.Default.Movement.performed += OnMovementPerformed;
            _inputAcions.Default.Movement.canceled += OnMovementEnd;
            _inputAcions.Default.Jump.started += OnJumpStarted;
        }

        public void SubsribeEventsSetings()
        {
            _inputAcions.Default.Start.started += OnStarted;
            _inputAcions.Default.Setings.started += OnSetings;
        }


        private void OnSetings(InputAction.CallbackContext callbackContext) => Setings?.Invoke();
        private void OnStarted(InputAction.CallbackContext callbackContext) => Started?.Invoke();
        private void OnJumpStarted(InputAction.CallbackContext callbackContext) => JumpStarted?.Invoke();
        private void OnMovementPerformed(InputAction.CallbackContext callbackContext) => MovementRecieved?.Invoke(callbackContext.ReadValue<Vector2>());
        private void OnMovementEnd(InputAction.CallbackContext callbackContext) => MovementEnd?.Invoke();



        public void Dispose()
        {
            _inputAcions.Default.Movement.performed -= OnMovementPerformed;
            _inputAcions.Default.Movement.canceled -= OnMovementEnd;
            _inputAcions.Default.Jump.started -= OnJumpStarted;
            _inputAcions.Disable();
        }
        public void DisposeSetings()
        {
            _inputAcions.Default.Start.started -= OnStarted;
            _inputAcions.Default.Setings.started -= OnSetings;
        }
    }
}
