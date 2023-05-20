using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStats))]
    public class BasePlayerController : MonoBehaviour
    {
        private bool _canJump = true;
        protected Rigidbody _rigidbody;
        protected PlayerStats _stats;


        protected virtual void Start()
        {
 
            _rigidbody = GetComponent<Rigidbody>();
            _stats = GetComponent<PlayerStats>();
            StartCoroutine(MoveForward());
        }

        protected void Jump()
        {
            if (_canJump)
            {
                _rigidbody.AddForce(transform.up * _stats.ForceJump, ForceMode.Impulse);
            }
            
        }

        private IEnumerator MoveForward()
        {
            while(true)
            {
                //_rigidbody.velocity += transform.forward * _stats.ForwardSpeed * Time.fixedDeltaTime;
                transform.position += transform.forward * _stats.ForwardSpeed * Time.deltaTime;
                //yield return new WaitForFixedUpdate();
                yield return null;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            _canJump = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            _canJump = false;
        }
    }
}