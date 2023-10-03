using UnityEngine;

namespace Assets.Scripts
{
    public class Patrolling : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private float _pathLength = 1;
        private int _directionLeft = -1;

        private Vector3 _leftPosition;
        private Vector3 _rightPosition;
        private Vector3 _targetPosition;

        private void Start()
        {
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

        public void SetPathLength(int value)
        {
            _pathLength = value;
        }

        private void Patrol()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _targetPosition,
                _speed * Time.deltaTime);
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

        private void TryFlip()
        {
            Vector3 scale = transform.localScale;
            
            if (_targetPosition == _leftPosition && transform.localScale.x > 0 ||
                 _targetPosition == _rightPosition && transform.localScale.x < 0)
            {
                scale.x *= _directionLeft;
            }

            transform.localScale = scale;
        }
    }
}