using System;
using UnityEngine;

namespace Game.Scripts
{
    public class CoinManager : MonoBehaviour
    {
        private MenuManager _menuManagerScript;

        private CoinController[] _coinControllers;

        [SerializeField] private GameObject superCoinPrefab;

        private int _coinCountStart;
        private int _coinsCollected;

        private bool _isSuperCoinExist;

        private void Awake()
        {
            _menuManagerScript = FindObjectOfType<MenuManager>();
            _coinControllers = FindObjectsOfType<CoinController>();
            _coinCountStart = _coinControllers.Length;
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
            
            _menuManagerScript.UpdateCoinCount();

            if (!_isSuperCoinExist && _coinsCollected >= _coinCountStart)
            {
                ShowSuperCoin();
            }
        }
    }
}