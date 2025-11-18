using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Catapult
    {
        private Transform _anchor;

        private float _upYPosition;
        private float _downYPosition;

        private bool _isReadyToFire = true;

        public bool IsReadyTiFire => _isReadyToFire;

        public Catapult(Transform anchor, float upPosiotion, float downPosition)
        {
            _anchor = anchor;
            _upYPosition = upPosiotion;
            _downYPosition = downPosition;
        }

        public void Fire()
        {
            _isReadyToFire = false;
            SetNewAnchorPosition(_upYPosition);
        }

        public void Reload()
        {
            SetNewAnchorPosition(_downYPosition);
            _isReadyToFire = true;
        }

        private void SetNewAnchorPosition(float newYPosition)
        {
            Vector3 firePosition = _anchor.localPosition;
            firePosition.y = newYPosition;

            _anchor.localPosition = firePosition;
        }
    }
}
