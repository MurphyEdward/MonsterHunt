using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _smoothSpeed = 0.07f;
    private Vector3 _offset = new Vector3(0, 0, -10);
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
    [SerializeField] private float _upLimit;
    [SerializeField] private float _downLimit;

    void LateUpdate()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothSpeed);
        

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
            Mathf.Clamp(transform.position.y, _downLimit, _upLimit),
            transform.position.z );
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(new Vector2(leftLimit, upLimit), new Vector2(rightLimit, upLimit));
    //    Gizmos.DrawLine(new Vector2(leftLimit, upLimit), new Vector2(leftLimit, downLimit));
    //    Gizmos.DrawLine(new Vector2(leftLimit, downLimit), new Vector2(rightLimit, downLimit));
    //    Gizmos.DrawLine(new Vector2(rightLimit, upLimit), new Vector2(rightLimit, downLimit));
    //}
}
