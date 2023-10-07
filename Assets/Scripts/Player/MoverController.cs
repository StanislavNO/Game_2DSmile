using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoverController : MonoBehaviour
    {
        private const string CommandHorizontalInput = "Horizontal";
        private const string CommandRun = "isRun";

        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;

        private Rigidbody2D _rigidBody;
        private float _inputX;
        private bool _isRun = false;
        private bool _leftRun;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _inputX = Input.GetAxis(CommandHorizontalInput);

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
            {
                scale.x *= -1;
            }

            transform.localScale = scale;
        }

        private void UseAnimationRun(bool isRun)
        {
            _animator.SetBool(CommandRun, isRun);
        }
    }
}