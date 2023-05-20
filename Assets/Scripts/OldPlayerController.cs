using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class OldPlayerController : BasePlayerController
    {
        protected override void Start()
        {
 
            base.Start();
        }

        private void FixedUpdate()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            var direction = Input.GetAxis("Horizontal") * _stats.SideSpeed * Time.fixedDeltaTime;

            if (direction == 0f) return;
            _rigidbody.velocity += direction * transform.right;
        }
    }
}