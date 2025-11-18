using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Catapult
    {
        private Rigidbody _addForcePoint;

        public Catapult(Rigidbody addForcePoint) =>
            _addForcePoint = addForcePoint;

        public void Fire(float force) =>
            _addForcePoint.AddForce(Vector3.up * force);
    }
}
