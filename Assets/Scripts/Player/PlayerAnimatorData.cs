using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAnimatorData : MonoBehaviour
    {
        public class Params
        {
            public readonly int Speed = Animator.StringToHash(nameof(Speed));
            public readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
            public readonly int StepsAmount = Animator.StringToHash(nameof(StepsAmount));
            public readonly int Attack = Animator.StringToHash(nameof(Attack));
        }
    }
}