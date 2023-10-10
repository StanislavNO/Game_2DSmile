using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Medicine : Loot
    {
        [SerializeField] private int _healthPoint;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                EventBus.CallMedicinePickedUp(_healthPoint);

                Destroy(gameObject);
            }
        }
    }
}