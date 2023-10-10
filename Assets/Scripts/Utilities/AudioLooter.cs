using UnityEngine;

namespace Assets.Scripts
{
    public class AudioLooter : MonoBehaviour
    {
        [SerializeField] private AudioSource _coin;
        [SerializeField] private AudioSource _medicine;

        private void OnEnable()
        {
            EventBus.CoinPickedUp.AddListener(_coin.Play);
            EventBus.MedicinePickedUp.AddListener(PlaySoundHeal);
        }

        private void PlaySoundHeal(int value)
        {
            _medicine.Play();
        }
    }
}