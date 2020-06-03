using UnityEngine.InputSystem;
using Bytes.Controllers;
using Bytes.Entities;

namespace Bytes.Input
{
    public class KeyboardDebugCommand : InputCommand, IDebugInput
    {
        public bool IsAddGreenApplePressed { get; set; } = false;
        public bool IsAddRedApplePressed { get; set; } = false;
        public bool IsAddMultiApplePressed { get; set; } = false;

        AmmoInventoryController ammoInventoryController;

        void Start()
        {
            inputActions.Player.Debug.performed += OnAddGreenAppleInput;
            ammoInventoryController = GetComponent<AmmoInventoryController>();
        }

        public override void Execute()
        {
            if (IsAddGreenApplePressed)
            {
                ammoInventoryController.Add(ReferenceController.Instance.ammo[WeaponType.GreenApple]);

                IsAddGreenApplePressed = false;
            }
        }

        void OnDisable()
        {
            inputActions.Player.Debug.performed -= OnAddGreenAppleInput;
        }

        void OnAddGreenAppleInput(InputAction.CallbackContext context)
        {
            IsAddGreenApplePressed = context.ReadValueAsButton();
        }
    }
}
