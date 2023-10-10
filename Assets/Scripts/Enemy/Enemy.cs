using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        private int _health;
        protected int _minHealth = 0;
        protected int _damage = 1;

        public int Damage => _damage;

        public void TakeDamage(int damage)
        {
            if (damage > _minHealth)
            {
                if (_health > damage)
                    _health -= damage;
                else
                    Destroy(gameObject);
            }
        }
    }
}