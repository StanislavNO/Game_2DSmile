using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] protected int _health;
        [SerializeField] protected int _damage;

        protected int _minHealth = 0;
        private readonly int AnimationTakeDamage = Animator.StringToHash("TakeDamage");

        public void TakeDamage(int damage)
        {
            if (damage > _minHealth)
            {
                if (_health > damage)
                    _health -= damage;
                else
                    Destroy(gameObject);
            }

            _animator.SetTrigger(AnimationTakeDamage);
        }
    }
}