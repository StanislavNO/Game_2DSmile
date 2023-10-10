using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private List<Loot> _loots;

        private void Start()
        {
            Loot loot = _loots[Random.Range(0, _loots.Count)];

            Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
}