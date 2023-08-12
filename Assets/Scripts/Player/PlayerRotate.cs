using UnityEngine;
using DG.Tweening;

namespace GeometryDash.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private JumpController _jumpController;

        private bool canRotate = true;

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (canRotate)
            {
                if (_jumpController.IsJumping())
                {
                    canRotate = false;

                    _target.DORotate(new Vector3(0, 0, _target.eulerAngles.z - 180f), 0.65f).OnComplete(() =>
                    {
                        canRotate = true;
                    });
                }
                else if (!_jumpController.IsGrounded())
                {
                    canRotate = false;

                    _target.DORotate(new Vector3(0, 0, _target.eulerAngles.z - 90f), 0.4f).OnComplete(() =>
                    {
                        canRotate = true;
                    });
                }
            }
        }
    }
}



