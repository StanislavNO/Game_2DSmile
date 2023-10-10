using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        private int Health;
        protected int _damage = 1;

        public int Damage => _damage;
    }
}