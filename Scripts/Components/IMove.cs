using UnityEngine;

namespace Bytes.Components
{
    public interface IMove
    {
        Vector3 MoveSpeed { get; set; }
        Vector3 Velocity { get; set; }
    }
}