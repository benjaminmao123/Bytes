using UnityEngine;

namespace Bytes.Controllers
{
    public interface IMovementController
    {
        void Move(Vector3 offset);
        bool IsGrounded { get; }
    }
}

