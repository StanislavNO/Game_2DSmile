using UnityEngine;

namespace Assets.Scripts
{
    public class Wallet : MonoBehaviour
    {
        private int _coins;

        public int Coins => _coins;

        private void OnEnable() => EventBus.CoinPickedUp.AddListener(AddCoin);

        private void AddCoin() => _coins++;
    }
}