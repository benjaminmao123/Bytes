using System;
using UnityEngine;
using Bytes.Input;

namespace Bytes.Controllers
{
    public class InputController : MonoBehaviour
    {
        InputCommand[] inputCommands;

        void Start()
        {
            inputCommands = GetComponents<InputCommand>();
        }

        void Update()
        {
            Array.ForEach(inputCommands, commands => commands.Execute());
        }
    }
}

