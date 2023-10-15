using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private UnityEvent _lifePointsOver;
        [SerializeField] private int _lifePoint;

        private int _minPoint = 0;

        private void Start()
        {
            EventBus.MedicinePickedUp.AddListener(Heal);
        }

        private void Update()
        {
            if (_lifePoint <= _minPoint)
            {
                _lifePointsOver.Invoke();
            }
        }

        public void TakeDamage(int value)
        {
            if (value > _minPoint)
            {
                if (_lifePoint > value)
                    _lifePoint -= value;
                else
                    _lifePointsOver.Invoke();
            }
        }

        private void Heal(int value)
        {
            if (value > _minPoint)
            {
                _lifePoint += value;
            }
        }
    }
}