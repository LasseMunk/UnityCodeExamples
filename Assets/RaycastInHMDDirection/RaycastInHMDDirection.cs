using System;
using UnityEngine;
using NaughtyAttributes;

namespace LasseMunk_RaycastInHDMDirection
{
    public class RaycastInHMDDirection : MonoBehaviour
    {
        [SerializeField] private Transform transformHMD;
        
        private Ray _ray;
        RaycastHit _raycastHit;
        private Vector3 _currentRaycastHitPosition;

        private void Start()
        {
            _ray = new Ray();
        }

        private void FixedUpdate()
        {
            if (transformHMD == null) return;
            
            _ray.origin = transformHMD.position;
            _ray.direction = transformHMD.transform.TransformDirection(Vector3.forward);
            
            Debug.DrawLine(_ray.origin, _ray.direction*20, Color.red, 0.1f);
            
            if (Physics.Raycast(_ray, out _raycastHit, 20f))
            {
                _currentRaycastHitPosition = new Vector3(_raycastHit.point.x, _raycastHit.point.y, _raycastHit.point.z);
                Debug.Log(_currentRaycastHitPosition);
            }
        }
    }

}