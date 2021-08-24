using UnityEngine;

namespace Game.Scripts
{
    public class CoinFind : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        private CoinManager _coinManagerScript;

        [SerializeField] private Renderer arrowRenderer;

        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;

        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float maxLerpDistance = 20f;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _coinManagerScript = FindObjectOfType<CoinManager>();
            startColor = arrowRenderer.material.color;
        }

        private void FixedUpdate()
        {
            if (!_gameManagerScript.IsGameStarted) return;
            
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

                //Обновить направление
                transform.rotation = Quaternion.Lerp(
                    transform.rotation, 
                    Quaternion.LookRotation(lookAt), 
                    Time.deltaTime * rotationSpeed
                );

                //Обновить цвет
                float lerpTime = (target.transform.position - transform.position).sqrMagnitude / maxLerpDistance;
                arrowRenderer.material.color = Color.Lerp(endColor, startColor, lerpTime);
            }
        }
    }
}