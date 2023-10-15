using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Coin : Loot
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Health player))
            {
                EventBus.CallCoinPickedUp();

                Destroy(gameObject);
            }
        }
    }
}