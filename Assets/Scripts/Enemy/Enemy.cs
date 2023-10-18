using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int Health;
        [SerializeField] protected int Damage;
        [SerializeField] private Animator _animator;

        protected readonly int MinHealth = 0;
        private readonly int _animationTakeDamage = Animator.StringToHash("TakeDamage");

        public void TakeDamage(int damage)
        {
            if (damage > MinHealth)
            {
                if (Health > damage)
                    Health -= damage;
                else
                    Destroy(gameObject);
            }

            _animator.SetTrigger(_animationTakeDamage);
        }
    }
}