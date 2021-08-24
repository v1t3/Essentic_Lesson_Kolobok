using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts
{
    public class CoinManager : MonoBehaviour
    {
        private MenuManager _menuManagerScript;

        [SerializeField] private GameObject superCoinPrefab;

        private List<CoinController> _coinControllerList = new List<CoinController>();

        [SerializeField] private AudioSource coinPickupAudio;

        public int CoinCountStart { get; private set; }
        public int CoinsCollected => CoinCountStart - _coinControllerList.Count;

        public bool IsSuperCoinExist { get; private set; }

        private void Awake()
        {
            _menuManagerScript = FindObjectOfType<MenuManager>();
            _coinControllerList = FindObjectsOfType<CoinController>().ToList();

            CoinCountStart = _coinControllerList.Count;
        }

        public void EnableCoins()
        {
            foreach (var coinController in _coinControllerList)
            {
                coinController.StartAnimation();
            }
        }

        private void ShowSuperCoin()
        {
            if (IsSuperCoinExist) return;

            Instantiate(superCoinPrefab, superCoinPrefab.transform.position, superCoinPrefab.transform.rotation);
            IsSuperCoinExist = true;
        }

        public void UpdateCoinsCount(CoinController coinController)
        {
            _coinControllerList.Remove(coinController);
            
            _menuManagerScript.UpdateCoinCountText();

            if (!IsSuperCoinExist && 0 == _coinControllerList.Count)
            {
                ShowSuperCoin();
            }
        }

        public CoinController GetClosest(Vector3 point)
        {
            float minDistance = Mathf.Infinity;
            CoinController closestCoin = null;
            
            for (int i = 0; i < _coinControllerList.Count; i++)
            {
                float distance = Vector3.Distance(point, _coinControllerList[i].transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCoin = _coinControllerList[i];
                }
            }

            return closestCoin;
        }

        public void PlayCoinPickupSound()
        {
            coinPickupAudio.Play();
        }
    }
}