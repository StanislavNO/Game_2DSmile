using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Mover _playerMover;

        private readonly int Run = Animator.StringToHash("isRun");
        private readonly int Jump = Animator.StringToHash("jump");

        private bool _isRun = false;
        private bool _startValueRun;

        private void Update()
        {
            _startValueRun = _isRun;
            _isRun = _playerMover.IsRun;

            if (_startValueRun != _isRun)
                UseAnimationRun(_isRun);
        }

        public void UseAnimationJump() => _animator.SetTrigger(Jump);

        private void UseAnimationRun(bool isRun) => _animator.SetBool(Run, isRun);
    }
}