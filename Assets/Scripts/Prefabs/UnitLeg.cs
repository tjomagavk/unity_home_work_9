using System;
using UnityEngine;

namespace Prefabs
{
    public class UnitLeg : MonoBehaviour
    {
        private float _currentX;
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private bool _positive;
        private bool _play = true;

        private int _speed = 200;

        private void Start()
        {
            _startRotation = transform.localRotation;
            _startPosition = transform.localPosition;
        }

        void FixedUpdate()
        {
            if (_play)
            {
                Animations();
            }
        }

        public void StartAnimation(bool positive, int speed)
        {
            _speed = speed * 50;
            _currentX = 0;
            _positive = positive;
            _play = true;
        }

        public void Stop()
        {
            _play = false;
            _currentX = 0;
            transform.localRotation = _startRotation;
            transform.localPosition = _startPosition;
        }


        private void Animations()
        {
            if (_currentX >= 45)
            {
                _positive = false;
            }
            else if (_currentX <= -45)
            {
                _positive = true;
            }

            if (_positive)
            {
                _currentX += Time.fixedDeltaTime * _speed;
            }
            else
            {
                _currentX -= Time.fixedDeltaTime * _speed;
            }

            Rotate(_currentX);
        }

        private void Rotate(float x)
        {
            Vector3 vector3 = new Vector3(x, 0, _startRotation.z * 100);
            transform.localRotation = Quaternion.Euler(vector3);
        }
    }
}