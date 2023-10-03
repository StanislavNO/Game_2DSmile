using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        private int _damage = 1;

        public int Damage => _damage;
    }
}