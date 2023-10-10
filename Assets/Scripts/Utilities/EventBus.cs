using UnityEngine.Events;

namespace Assets.Scripts
{
    public class EventBus
    {
        public static readonly UnityEvent CoinPickedUp = new UnityEvent();
        public static readonly UnityEvent<int> MedicinePickedUp = new UnityEvent<int>();

        public static void CallCoinPickedUp() => CoinPickedUp?.Invoke();

        public static void CallMedicinePickedUp(int value) => MedicinePickedUp?.Invoke(value);
    }
}