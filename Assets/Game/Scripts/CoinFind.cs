using UnityEngine;

namespace Game.Scripts
{
    public class CoinFind : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        private CoinManager _coinManagerScript;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _coinManagerScript = FindObjectOfType<CoinManager>();
        }

        private void FixedUpdate()
        {
            if (!_gameManagerScript.isGameStarted) return;
            
            FindCoin();
        }

        private void FindCoin()
        {
            CoinController coin = _coinManagerScript.GetClosest(transform.position);

            if (coin)
            {
                Vector3 lookAt = coin.gameObject.transform.position - transform.position;
                lookAt.y = 0;

                transform.rotation = Quaternion.LookRotation(lookAt);
            } 
            else if (_coinManagerScript.IsSuperCoinExist)
            {
                Vector3 superCoinPosition = FindObjectOfType<SuperCoinController>().transform.position;
                Vector3 lookAt = superCoinPosition - transform.position;
                lookAt.y = 0;

                transform.rotation = Quaternion.LookRotation(lookAt);
            }
        }
    }
}