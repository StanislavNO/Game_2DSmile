using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _direction;
        [SerializeField] private float _coolDown;

        private bool _isAttack;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _isAttack = true;

                if(_isAttack) 
                    StartCoroutine(Attack(_coolDown));
            }
        }

        private IEnumerator Attack(float delay)
        {
            _isAttack = false;

            Instantiate(_bullet, _direction.position, Quaternion.identity);

            yield return new WaitForSecondsRealtime(delay);

            _isAttack = true;
        }
    }
}