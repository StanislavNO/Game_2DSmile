using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private UnityEvent _damageDown;

        private int _health = 500;

        public int Health => _health;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                StartCoroutine(DamageSetter());
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            StopAllCoroutines();
        }

        private  IEnumerator DamageSetter()
        {
            WaitForSeconds delay = new WaitForSeconds(1);

            while (_health > 0)
            {
                _health--;
                _damageDown.Invoke();

                yield return delay;
            }
        }
    }
}