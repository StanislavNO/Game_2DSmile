using System.Diagnostics;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts
{
    public class EventBus
    {
        public static readonly UnityEvent CoinPickedUp = new UnityEvent();

        public static void CallCoinPickedUp()
        {
            if (CoinPickedUp != null)
                CoinPickedUp.Invoke();
        }
    }
}