using System;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class CatapultLoader
    {
        private Projectile _projectile;
        private Transform _loadPoint;

        private Spawner<Projectile> _spawner;

        public CatapultLoader(Projectile projectile, Transform loadPoint)
        {
            _projectile = projectile;
            _loadPoint = loadPoint;

            _spawner = new(_projectile);
        }

        public void Load()
        {
            Projectile spawned = _spawner.Spawn();
            spawned.transform.position = _loadPoint.position;
        }
    }
}
