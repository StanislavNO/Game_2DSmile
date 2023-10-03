using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Patrolling _enemy;
        [SerializeField] private int _pathLength;

        private void Start()
        {
            Patrolling enemy = Instantiate(_enemy, transform.position, Quaternion.identity);

            enemy.SetPathLength(_pathLength);
        }
    }
}