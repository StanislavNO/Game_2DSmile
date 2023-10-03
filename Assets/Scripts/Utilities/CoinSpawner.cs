using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coin;

        private void Start()
        {
            Instantiate(_coin, transform.position, Quaternion.identity);
        }
    }
}