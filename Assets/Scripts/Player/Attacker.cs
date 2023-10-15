using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private int _coolDown = 1;
        private bool _canAttack = true;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (_canAttack)
                {
                    enemy.TakeDamage(Hit());
                    StartCoroutine(HitCoolDown());
                }
            }
        }

        private IEnumerator HitCoolDown()
        {
            WaitForSecondsRealtime delay = new WaitForSecondsRealtime(_coolDown);

            _canAttack = false;
            yield return delay;
            _canAttack = true;
        }

        private int Hit()
        {
            return _damage;
        }
    }
}