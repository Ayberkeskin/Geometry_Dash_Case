using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

namespace GeometryDash.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private JumpController _jumpController;

        bool deno;

        private void FixedUpdate()
        {
            Rotate();            
        }
        private void Rotate()
        {
            if (_jumpController.IsJumping())
            {
                deno = false;
                _target.transform.DORotate(_target.rotation.eulerAngles - new Vector3(0, 0, 180), 0.65f).OnComplete(() => deno = true);
            }
            if (deno && !_jumpController.IsGrounded())
            {
                 _target.transform.DORotate(_target.rotation.eulerAngles - new Vector3(0, 0, 90), 0.4f);
            }
        }
    }
}
