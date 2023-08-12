using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GeometryDash.Player
{
    public class FlyController : MonoBehaviour
    {
        Rigidbody2D _rb;
        [SerializeField] private float upwardForce=10f;
        [SerializeField] private Transform _planeBody;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            PlaneFly();
            PlaneRotation();
        }

        private void PlaneFly() 
        {
            if (Input.GetMouseButton(0)) 
            {
                _rb.velocity = Vector2.up * upwardForce;
            }
        }
        private void PlaneRotation()
        {
            if (_rb.velocity.y>0) 
            {
                _planeBody.DORotate(new Vector3(0, 0, 25), 0.45f);
            }
            else if (_rb.velocity.y < 0)
            {
                _planeBody.DORotate(new Vector3(0, 0, -25), 0.45f);
            }
            else if (_rb.velocity.y == 0)
            {
                _planeBody.DORotate(new Vector3(0, 0, 0), 0.45f);
            }
        }
    }

}

