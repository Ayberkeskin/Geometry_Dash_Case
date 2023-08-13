using UnityEngine;
using DG.Tweening;

namespace GeometryDash.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private JumpController _jumpController;

        private bool _canRotate = true;

        private void FixedUpdate()
        {
            Rotate();
        }


        private void Rotate()
        {
            //on the ground, ready to jump and spin
            if (_jumpController.IsGrounded())
                _canRotate = true;
            
            if (_canRotate)
            {
                if (_jumpController.IsJumping())
                {
                    _canRotate = false;

                    _target.DORotate(new Vector3(0, 0, _target.eulerAngles.z - 180f), 0.45f).OnComplete(() =>
                    {
                        //If it is still in the air after the rotate is finished, the process is repeated, so check if it is on the ground.
                        if (_jumpController.IsGrounded())
                            _canRotate = true;
                    });
                }
                else if (!_jumpController.IsGrounded())
                {
                    _canRotate = false;

                    _target.DORotate(new Vector3(0, 0, _target.eulerAngles.z - 90f), 0.23f).OnComplete(() =>
                    {
                        //If it is still in the air after the rotate is finished, the process is repeated, so check if it is on the ground.
                        if (_jumpController.IsGrounded())
                            _canRotate = true;
                    });
                }
            }
        }
    }
}