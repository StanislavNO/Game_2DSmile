using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private int _health = 5;
        private int _minHealth = 0;

        public int Health { get => _health; }

        private void Start()
        {
            EventBus.MedicinePickedUp.AddListener(Heal);
        }

        private void Update()
        {
            if (_health <= 0)
            {
                StartCoroutine(GetDeath());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                
            }
        }

        public void TakeDamage(int value)
        {
            if (value > _minHealth)
            {
                if (_health > value)
                    _health -= value;
                else
                    GetDeath();
            }
        }

        private void Heal(int value)
        {
            if (value > _minHealth)
            {
                _health += value;
            }

        }

        private IEnumerator GetDeath()
        {
            float pauseTime = 0f;
            float delay = 3f;

            Time.timeScale = pauseTime;

            yield return new WaitForSecondsRealtime(delay);

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}