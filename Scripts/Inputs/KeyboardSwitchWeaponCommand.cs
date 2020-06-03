using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Bytes.Components;
using Bytes.Entities;

namespace Bytes.Input
{
    public class KeyboardSwitchWeaponCommand : InputCommand, ISwitchWeaponInput
    {
        public bool IsSwitchWeaponPressed { get; set; } = false;
        IAttack attack;

        void Start()
        {
            inputActions.Player.SwitchWeapon.performed += OnSwitchWeaponInput;

            attack = GetComponent<IAttack>();
        }

        public override void Execute()
        {
            if (IsSwitchWeaponPressed && !KeyboardPauseCommand.isPaused)
            {
                ++attack.CurrentWeapon;

                if ((int)attack.CurrentWeapon >= Enum.GetNames(typeof(WeaponType)).Length)
                    attack.CurrentWeapon = 0;

                IsSwitchWeaponPressed = false;
                Debug.Log(attack.CurrentWeapon);
            }
        }

        void OnDisable()
        {
            inputActions.Player.SwitchWeapon.performed -= OnSwitchWeaponInput;
        }

        void OnSwitchWeaponInput(InputAction.CallbackContext context)
        {
            IsSwitchWeaponPressed = context.ReadValueAsButton();
        }
    }
}