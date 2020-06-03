using UnityEngine;

namespace Bytes.Controllers
{
    public class CharacterControllerMovement : MonoBehaviour, IMovementController
    {
        CharacterController characterController;

        public bool IsGrounded { get; private set; }

        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector3 offset)
        {
            characterController.Move(offset * Time.deltaTime);
            IsGrounded = characterController.isGrounded;
        }
    }
}

