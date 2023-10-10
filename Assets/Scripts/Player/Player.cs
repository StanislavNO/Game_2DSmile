using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private int _health = 5;

        public int Health => _health;

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

        private void Heal(int value)
        {
            if (value > 0)
            {
                _health += value;
            }

        }

        private void TakeDamage()
        {

        }

        private IEnumerator GetDeath()
        {
            float pauseTime = 0f;
            float delay = 3f;

            Time.timeScale = pauseTime;

            yield return new WaitForSeconds(delay);

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}