using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private int _progress = 0;

        private float _step = 10f;
        private int _currentIndex = 0;
        private float _lastZ = 65f;

        [SerializeField]
        private Transform _player;
        [SerializeField, Min(1f)]
        private int _health = 5;

        [Space, SerializeField]
        private Transform[] _blocks;
        [SerializeField]
        private Text _text;
      //  [SerializeField]
      //  private Text _text2;

        private void Awake()
        {
            Instance = this;
            
            var trigger = FindObjectOfType<TriggerComponent>();
        }

        private void Update()
        {
            if (_player.position.y < -3f) GetDamage();
        }
        public void GetDamage()
        {
            _health -= 1;

            Debug.Log("Health: " + _health);

            if (_health <=0)
            {
                Debug.Log("---You're dead---");
                UnityEditor.EditorApplication.isPaused = true;
            }
        }

        public void UpdateLevel()
        {
            _progress++;
            _text.text = _progress.ToString();

           // _text2.text = _health.ToString();

            _lastZ += _step;
            var position = _blocks[_currentIndex].position;
            position.z = _lastZ;
            _blocks[_currentIndex].position = position;

            

            _currentIndex++;

            if(_currentIndex>=_blocks.Length)
            {
                _currentIndex = 0;
            }
        }
    }
}