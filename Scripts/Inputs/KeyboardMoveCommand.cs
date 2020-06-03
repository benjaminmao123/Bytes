using UnityEngine.InputSystem;
using UnityEngine;
using Bytes.Controllers;
using Bytes.Settings;
using Bytes.Components;

namespace Bytes.Input
{
    public class KeyboardMoveCommand : InputCommand, IMoveInput
    {
        IMovementController moveController;
        IMove moveable;

        public Vector3 MoveDirection { get; set; }

        private void Start()
        {
            inputActions.Player.Movement.performed += OnMoveInput;

            moveController = GetComponent<IMovementController>();
            moveable = GetComponent<IMove>();
        }

        public override void Execute()
        {
            if (moveable != null && !KeyboardPauseCommand.isPaused)
            {
                float velocityY = moveable.Velocity.y + Time.deltaTime * -EnvironmentSettings.Gravity;

                moveable.Velocity = (transform.right * MoveDirection.x * moveable.MoveSpeed.x) +
                    (transform.forward * MoveDirection.z * moveable.MoveSpeed.z);

                moveable.Velocity = new Vector3(moveable.Velocity.x, velocityY, moveable.Velocity.z);

                moveController.Move(moveable.Velocity);
            }
        }

        void OnDisable()
        {
            inputActions.Player.Movement.performed -= OnMoveInput;
        }

        void OnMoveInput(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();

            MoveDirection = new Vector3(value.x, 0, value.y);
        }
    }
}

