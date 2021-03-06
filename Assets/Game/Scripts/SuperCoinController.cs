using UnityEngine;

namespace Game.Scripts
{
    public class SuperCoinController : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _gameManagerScript.SetPlayerWin();
                Destroy(gameObject);
            }
        }
    }
}
