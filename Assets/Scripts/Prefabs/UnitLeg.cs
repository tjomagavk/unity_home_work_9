using UnityEngine;

namespace Prefabs
{
    public class UnitLeg : MonoBehaviour
    {
        private float _currentX;
        private bool _positive;
        private bool _play = true;

        private int _speed = 200;

        void Update()
        {
            if (_play)
            {
                Animations();
            }
        }

        public void StartAnimation(bool positive, int speed)
        {
            _speed = speed * 100;
            _currentX = 0;
            _positive = positive;
            _play = true;
        }

        public void Stop()
        {
            _play = false;
            _currentX = 0;
            Rotate(_currentX);
        }


        private void Animations()
        {
            if (_currentX >= 45)
            {
                _positive = false;
            }

            if (_currentX <= -45)
            {
                _positive = true;
            }

            if (_positive)
            {
                _currentX += Time.deltaTime * _speed;
            }
            else
            {
                _currentX -= Time.deltaTime * _speed;
            }

            Rotate(_currentX);
        }

        private void Rotate(float x)
        {
            Vector3 vector3 = new Vector3(x, 0, 0);
            transform.localRotation = Quaternion.Euler(vector3);
        }
    }
}