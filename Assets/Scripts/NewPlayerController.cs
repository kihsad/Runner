using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class NewPlayerController : BasePlayerController
    {
        private RunnerControls _controls;

        private void Update()
        {
            var direction = _controls.Player.SideMove.ReadValue<float>() * _stats.SideSpeed * Time.deltaTime;
            transform.position += direction * transform.right;
        }

        private void Awake()
        {
            _controls = new RunnerControls();
            _controls.Player.Jump.performed += _ => Jump();
        }

        private void OnEnable()
        {
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }
    }
}