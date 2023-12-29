using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private BoxCollider _colliderTrigger;

    [SerializeField] private float _moveSpeed;


    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed,
                                            _rigidbody.velocity.y,
                                            _joystick.Vertical * _moveSpeed
                                         );

        if (_colliderTrigger)
        {
            _animator.SetBool("Grounded", true);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0 && _colliderTrigger)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                _animator.SetFloat("MoveSpeed", _moveSpeed);
            }
            else
            {
                _animator.SetFloat("MoveSpeed", 0);
            }
        }
        else
        {
            _animator.SetBool("Grounded", false);
        }

    }
}
