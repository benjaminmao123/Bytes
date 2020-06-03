using UnityEngine;
using UnityEngine.InputSystem;
using Bytes.Components;
using Bytes.Controllers;

namespace Bytes.Input
{
    public class MouseAttackCommand : InputCommand, IAttackInput
    {
        IAttackController attackController;
        IAttack attack;
        float timeBetweenAttacks;

        public bool IsAttackPressed { get; set; } = false;

        void Start()
        {
            inputActions.Player.Attack.performed += OnAttackInput;

            attack = GetComponent<IAttack>();
            timeBetweenAttacks = attack.AttackSpeed;
            attackController = GetComponent<IAttackController>();
        }

        public override void Execute()
        {
            timeBetweenAttacks += Time.deltaTime;

            if (IsAttackPressed && !KeyboardPauseCommand.isPaused)
            {
                if (timeBetweenAttacks >= attack.AttackSpeed)
                {
                    timeBetweenAttacks = 0.0f;
                    attackController.Attack();
                    Debug.Log("Attack Pressed");
                }

                IsAttackPressed = false;
            }
        }

        void OnDisable()
        {
            inputActions.Player.Attack.performed -= OnAttackInput;
        }

        void OnAttackInput(InputAction.CallbackContext context)
        {
            IsAttackPressed = context.ReadValueAsButton();
        }
    }
}
