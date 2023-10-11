using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class HuntingZone : MonoBehaviour
    {
        private Patrolling _enemy;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Patrolling>(out Patrolling enemy))
                _enemy = enemy;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                if (_enemy != null)
                {
                    Vector3 target = new Vector3(
                        player.transform.position.x,
                        _enemy.gameObject.transform.position.y,
                        _enemy.gameObject.transform.position.z);

                    _enemy.StartHunting(target);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                _enemy?.EndHunting();
            }
        }
    }
}