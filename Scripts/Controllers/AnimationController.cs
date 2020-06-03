using UnityEngine;

namespace Bytes.Controllers
{
    public abstract class AnimationController : MonoBehaviour
    {
        protected Animator animator;

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
        }
    }
}

