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
   
        private void FixedUpdate()
        {
            Rotate();
        }
        private void Rotate()
        {
            if (_jumpController.IsJumping())
            {
                _target.transform.DORotate(_target.rotation.eulerAngles - new Vector3(0, 0, 180), 0.5f);
            }
        }
    }
}
