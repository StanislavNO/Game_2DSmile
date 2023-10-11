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

        private void Start()
        {
            _isRun = false;
            _rigidBody = GetComponent<Rigidbody2D>();
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

            if (scale.x > 0 && leftRun || scale.x < 0 && leftRun == false)
                scale.x *= -1;

            transform.localScale = scale;
        }

        private void UseAnimationRun(bool isRun) => _animator.SetBool(Run, isRun);
    }
}