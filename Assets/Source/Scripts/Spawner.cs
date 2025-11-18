using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Spawner<T> where T : MonoBehaviour
    {
        private T _prefab;

        public Spawner(T prefab) =>
            _prefab = prefab;

        public T Spawn()
        {
            return Object.Instantiate(_prefab);
        }
    }
}
