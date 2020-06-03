using UnityEngine;
using UnityEngine.InputSystem;
using Bytes.Controllers;
using Bytes.Settings;
using Bytes.Components;

namespace Bytes.Input
{
    public class KeyboardJumpCommand : InputCommand, IJumpInput
    {
        IMovementController moveController;
        IMove moveable;

        public bool IsJumpPressed { get; set; } = false;

        void Start()
        {
            inputActions.Player.Jump.performed += OnJumpInput;

            moveController = GetComponent<IMovementController>();
            moveable = GetComponent<IMove>();
        }

        public override void Execute()
        {
            if (IsJumpPressed && !KeyboardPauseCommand.isPaused)
            {
                if (moveController.IsGrounded)
                {
                    float velocityY = Mathf.Sqrt(-2 * -EnvironmentSettings.Gravity * moveable.MoveSpeed.y);
                    moveable.Velocity = new Vector3(moveable.Velocity.x, velocityY, moveable.Velocity.z);
                }

                IsJumpPressed = false;
            }
        }

        void OnDisable()
        {
            inputActions.Player.Jump.performed -= OnJumpInput;
        }

        void OnJumpInput(InputAction.CallbackContext context)
        {
            IsJumpPressed = context.ReadValueAsButton();
        }
    }
}
