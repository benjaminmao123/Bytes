using UnityEngine;
using Bytes.Components;

namespace Bytes.Controllers
{
    public class PlayerAnimationController : AnimationController
    {
        IMove moveable;
        IMovementController movementController;
        bool isLanding = false;

        override protected void Start()
        {
            base.Start();

            moveable = GetComponent<IMove>();
            movementController = GetComponent<IMovementController>();
        }

        void Update()
        {
            Run();
            Jump();
        }

        private void FixedUpdate()
        {
            if (moveable.Velocity.y < 0 && !movementController.IsGrounded)
                isLanding = Physics.BoxCast(transform.position, transform.lossyScale / 2, -transform.up, transform.rotation, 1f);
        }

        void Run()
        {
            animator.SetFloat("velocityX", moveable.Velocity.x);
            animator.SetFloat("velocityZ", moveable.Velocity.z);
        }

        void Jump()
        {
            animator.SetFloat("velocityY", moveable.Velocity.y);
            animator.SetBool("isGrounded", movementController.IsGrounded);
            animator.SetBool("isLanding", isLanding);
        }
    }
}

