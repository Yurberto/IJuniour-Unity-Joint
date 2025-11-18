using UnityEngine;

namespace Assets.Source.Scripts
{
    public class SwingOscillator
    {
        private Rigidbody _saddle;

        public SwingOscillator(Rigidbody saddle) =>
            _saddle = saddle;

        public void Swing(float force) =>
            _saddle.AddForce(_saddle.transform.forward * force);
    }
}
