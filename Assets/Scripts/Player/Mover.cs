using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private const string HorizontalInput = "Horizontal";

        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;

        private readonly int Run = Animator.StringToHash("isRun");
        private Rigidbody2D _rigidBody;

        private bool _isRun;
        private bool _leftRun;
        private float _inputX;
        private float _startLocalScaleX;

        private void Start()
        {
            _isRun = false;
            _rigidBody = GetComponent<Rigidbody2D>();
            _startLocalScaleX = transform.localScale.x;
        }

        private void Update()
        {
            _inputX = Input.GetAxis(HorizontalInput);

            if (_inputX != 0)
            {
                _isRun = true;

                if (_inputX < 0)
                    _leftRun = true;
                else
                    _leftRun = false;

                Flip(_leftRun);
            }
            else
                _isRun = false;

            UseAnimationRun(_isRun);
        }

        private void FixedUpdate()
        {
            Vector2 movement = new Vector2(_inputX * _speed, _rigidBody.velocity.y);

            _rigidBody.velocity = movement;
        }

        private void Flip(bool leftRun)
        {
            Vector3 scale = transform.localScale;

            if (scale.x == _startLocalScaleX && leftRun || 
                scale.x != _startLocalScaleX && leftRun == false)
                scale.x = -scale.x;

            transform.localScale = scale;
        }

        private void UseAnimationRun(bool isRun) => _animator.SetBool(Run, isRun);
    }
}