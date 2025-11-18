using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Rigidbody _swingSaddle;
        [SerializeField] private Rigidbody _catapultPoint;
        [SerializeField] private float _swingForce = 500f;
        [SerializeField] private float _catapultForce = 1000f;

        private InputReader _inputReader = new();
        private Rocker _rocker;
        private Catapult _catapult;

        private void Awake()
        {
            _rocker = new Rocker(_swingSaddle);
            _catapult = new Catapult(_catapultPoint);
        }

        private void OnEnable()
        {
            _inputReader.SwingingButtonPressed += Swing;
            _inputReader.FireProjectileButtonPressed += FireProjectile;
        }

        private void OnDisable()
        {
            _inputReader.SwingingButtonPressed -= Swing;
            _inputReader.FireProjectileButtonPressed -= FireProjectile;
        }

        private void Update() =>
            _inputReader.Update();

        private void Swing() =>
            _rocker.Swing(_swingForce);

        private void FireProjectile() =>
            _catapult.Fire(_catapultForce);
    }
}
