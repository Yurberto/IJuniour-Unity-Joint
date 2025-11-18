using System;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class InputReader
    {
        public event Action SwingingButtonPressed;
        public event Action FireProjectileButtonPressed;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SwingingButtonPressed?.Invoke();

            if (Input.GetKeyDown(KeyCode.Q))
                FireProjectileButtonPressed?.Invoke();
        }
    }

}
