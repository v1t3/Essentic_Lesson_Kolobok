using System;
using UnityEngine;

namespace Game.Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        private EnemyController[] _enemyControllers;

        private void Awake()
        {
            _enemyControllers = FindObjectsOfType<EnemyController>();
        }

        public void StopEnemies()
        {
            foreach (var enemy in _enemyControllers)
            {
                enemy.StopWalkSound();
            }
        }
    }
}