using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Rocker
    {
        private Rigidbody _saddle;

        public Rocker(Rigidbody saddle) =>
            _saddle = saddle;

        public void Swing(float force) =>
            _saddle.AddForce(_saddle.transform.forward * force);
    }
}
