using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Patrolling : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _pathLength = 1;

        private Vector3 _leftPosition;
        private Vector3 _rightPosition;
        private Vector3 _targetPosition;
        private Vector3 _startPosition;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _startPosition = transform.position;

            _rightPosition = transform.position +
                Vector3.right * _pathLength;

            _leftPosition = transform.position -
                Vector3.right * _pathLength;

            _targetPosition = _leftPosition;
        }


        private void Update()
        {
            Patrol();
            TryFlip();
            TryChangingPath();
        }

        public void StartHunting(Vector3 playerPosition)
        {
            _targetPosition = playerPosition;
        }

        public void EndHunting()
        {
            _targetPosition = _startPosition;
        }

        private void Patrol()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _targetPosition,
                _speed * Time.deltaTime);
        }

        private void TryFlip()
        {
            if (_targetPosition.x < transform.position.x)
                _spriteRenderer.flipX = true;
            else
                _spriteRenderer.flipX = false;
        }

        private void TryChangingPath()
        {
            if (transform.position.x == _targetPosition.x)
            {
                if (_targetPosition.x == _leftPosition.x)
                    _targetPosition = _rightPosition;
                else
                    _targetPosition = _leftPosition;
            }
        }
    }
}