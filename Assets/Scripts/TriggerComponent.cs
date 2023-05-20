using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;
        [SerializeField]
        private bool _isDamage;

        private void Start()
        {
            _collider.isTrigger = true; 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BasePlayerController>() == null) return;

            if(_isDamage)
            {
                GameManager.Instance.GetDamage();

            }
            else
            {
                GameManager.Instance.UpdateLevel();
            }
        }
    }
}