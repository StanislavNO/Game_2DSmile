using UnityEngine;

namespace Assets.Scripts
{
    public class GameOver : MonoBehaviour
    {
        public void Finish()
        {
            float pauseTime = 0f;

            Time.timeScale = pauseTime;
        }
    }
}