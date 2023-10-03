using UnityEngine;

namespace Assets.Scripts
{
    public class AudioCoiner : MonoBehaviour
    {
        [SerializeField] private AudioSource _sound;

        private void OnEnable()
        {
            EventBus.CoinPickedUp.AddListener(_sound.Play);
        }
    }
}