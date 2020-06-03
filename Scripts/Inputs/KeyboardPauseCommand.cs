using Bytes.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bytes.Input
{
    public class KeyboardPauseCommand : InputCommand, IPauseInput
    {
        public static bool isPaused = false;
        public bool IsPausePressed { get; set; } = false;
        [SerializeField] GameObject canvas;

        void Start()
        {
            inputActions.Player.Pause.performed += OnPauseInput;
        }

        public override void Execute()
        {
            if (IsPausePressed && !isPaused)
            {
                canvas.gameObject.SetActive(true);

                isPaused = true;
            }

            IsPausePressed = false;
        }

        void OnDisable()
        {
            inputActions.Player.Pause.performed -= OnPauseInput;
        }

        void OnPauseInput(InputAction.CallbackContext context)
        {
            IsPausePressed = context.ReadValueAsButton();
        }
    }
}

