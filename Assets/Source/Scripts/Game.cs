using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Game : MonoBehaviour
    {
        [Header("Swing")]
        [SerializeField] private Rigidbody _swingSaddle;
        [SerializeField] private float _swingForce = 500f;

        [Header("Catapult")]
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Transform _projectilePoint;
        [Space]
        [SerializeField] private Transform _catapultAnchor;
        [SerializeField, Range(4f, 100f)] private float _upYValue;
        [SerializeField, Range(-100f, -4f)] float _downYValue;

        private InputReader _inputReader = new();
        private SwingOscillator _swingOscillator;
        private Catapult _catapult;
        private CatapultLoader _loader;

        private void Awake()
        {
            _swingOscillator = new SwingOscillator(_swingSaddle);
            _catapult = new Catapult(_catapultAnchor, _upYValue, _downYValue);
            _loader = new CatapultLoader(_prefab, _projectilePoint);
        }

        private void OnEnable()
        {
            _inputReader.SwingingButtonPressed += Swing;

            _inputReader.ToggleCatapultButtonPressed += ToggleCatapult;
            _inputReader.LoadProjectileButtonPressed += LoadProjectile;
        }

        private void OnDisable()
        {
            _inputReader.SwingingButtonPressed -= Swing;

            _inputReader.ToggleCatapultButtonPressed -= ToggleCatapult;
            _inputReader.LoadProjectileButtonPressed -= LoadProjectile;
        }

        private void Update() =>
            _inputReader.Update();

        private void Swing() =>
            _swingOscillator.Swing(_swingForce);

        private void ToggleCatapult()
        {
            if (_catapult.IsReadyTiFire)
                _catapult.Fire();
            else
                _catapult.Reload();
        }

        private void LoadProjectile()
        {
            _loader.Load();
        }
    }
}
