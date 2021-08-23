using UnityEngine;

namespace Game.Scripts
{
    public class CoinFind : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        private CoinManager _coinManagerScript;

        [SerializeField] private float rotationSpeed = 5f;

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
            GameObject target = null;
            CoinController coin = _coinManagerScript.GetClosest(transform.position);
            
            if (coin)
            {
                target = coin.gameObject;
            } 
            else if (_coinManagerScript.IsSuperCoinExist)
            {
                target = FindObjectOfType<SuperCoinController>().gameObject;
            }

            if (target)
            {
                Vector3 lookAt = target.transform.position - transform.position;
                lookAt.y = 0;

                transform.rotation = Quaternion.Lerp(
                    transform.rotation, 
                    Quaternion.LookRotation(lookAt), 
                    Time.deltaTime * rotationSpeed
                );
            }
        }
    }
}