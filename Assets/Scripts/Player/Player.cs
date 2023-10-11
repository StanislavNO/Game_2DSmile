using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _health = 1;

        private int _coolDown = 1;
        private int _minHealth = 0;
        private bool canAttack = true;

        private void Start()
        {
            EventBus.MedicinePickedUp.AddListener(Heal);
        }

        private void Update()
        {
            if (_health <= 0)
            {
                GameOver();
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (canAttack) 
                { 
                    enemy.TakeDamage(Attack());
                    StartCoroutine(AttackCoolDown());
                }
            }
        }

        private IEnumerator AttackCoolDown()
        {
            canAttack = false;
            yield return new WaitForSecondsRealtime(_coolDown);
            canAttack = true;
        }

        public void TakeDamage(int value)
        {
            if (value > _minHealth)
            {
                if (_health > value)
                    _health -= value;
                else
                    GameOver();
            }
        }

        private void Heal(int value)
        {
            if (value > _minHealth)
            {
                _health += value;
            }
        }

        private int Attack()
        {
            return _damage;
        }

        private void GameOver()
        {
            int randomNumber = 100;
            float pauseTime = 0f;

            transform.position += Vector3.up * randomNumber;

            Time.timeScale = pauseTime;
        }
    }
}