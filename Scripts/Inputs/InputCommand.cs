using UnityEngine;

namespace Bytes.Input
{
    public abstract class InputCommand : MonoBehaviour
    {
        protected InputActions inputActions;

        private void Awake()
        {
            inputActions = new InputActions();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public virtual void Execute()
        {

        }

        public virtual void LateExecute()
        {

        }
    }
}

