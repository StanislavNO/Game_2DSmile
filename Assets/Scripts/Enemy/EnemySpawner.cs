using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        private void Start()
        {
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        }
    }
}