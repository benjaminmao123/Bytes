using UnityEngine;
using UnityEngine.InputSystem;
using Bytes.Components;

namespace Bytes.Input
{
    public class MouseRotationCommand : InputCommand, IRotationInput
    {
        float xRotation = 0;
        IRotate rotateable;
        public Transform cameraTransform;

        public Vector3 RotationDirection { get; set; }

        void Start()
        {
            inputActions.Player.Aim.performed += OnRotationInput;

            rotateable = GetComponent<IRotate>();
        }

        public override void Execute()
        {
            if (rotateable != null && !KeyboardPauseCommand.isPaused)
            {
                float mouseX = RotationDirection.x * rotateable.RotationSpeed * Time.deltaTime;
                float mouseY = RotationDirection.y * rotateable.RotationSpeed * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                transform.Rotate(Vector3.up * mouseX);
            }
        }

        void OnDisable()
        {
            inputActions.Player.Aim.performed -= OnRotationInput;
        }

        void OnRotationInput(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();

            RotationDirection = new Vector3(value.x, value.y, 0);
        }
    }
}
