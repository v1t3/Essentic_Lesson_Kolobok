using System;
using UnityEngine;

namespace Game.Scripts
{
    public class CoinManager : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        private CoinController[] _coinControllers;

        [SerializeField] private GameObject superCoinPrefab;

        [SerializeField] private int _coinCountStart;

        [SerializeField] private int _coinsCollected;

        private bool _isSuperCoinExist;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _coinControllers = FindObjectsOfType<CoinController>();

            _coinCountStart = _coinControllers.Length;
        }

        private void FixedUpdate()
        {
            if (!_gameManagerScript.isGameStarted) return;

            if (!_isSuperCoinExist && _coinsCollected >= _coinCountStart)
            {
                ShowSuperCoin();
            }
        }

        public int GetCollectedCoinsCount()
        {
            return _coinsCollected;
        }

        public void EnableCoins()
        {
            foreach (var coinController in _coinControllers)
            {
                coinController.StartAnimation();
            }
        }

        private void ShowSuperCoin()
        {
            if (_isSuperCoinExist) return;

            Instantiate(superCoinPrefab, superCoinPrefab.transform.position, superCoinPrefab.transform.rotation);
            _isSuperCoinExist = true;
        }

        public void AddCoinsCollected(int value)
        {
            _coinsCollected += value;
        }
    }
}