using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private CoinManager _coinManagerScript;
        
        private MenuManager _menuManagerScript;
        
        public bool IsGameStarted { get; private set; }

        private void Awake()
        {
            _coinManagerScript = FindObjectOfType<CoinManager>();
            _menuManagerScript = FindObjectOfType<MenuManager>();
        }

        private void Start()
        {
            IsGameStarted = false;
            _menuManagerScript.ShowInterface();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public void StartGame()
        {
            IsGameStarted = true;
            _menuManagerScript.ToggleHelloPanel();
            _menuManagerScript.UpdateCoinCountText();
            _coinManagerScript.EnableCoins();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StopGame()
        {
            Debug.Log("Quit");
            IsGameStarted = false;
            Application.Quit();
        }

        public void SetPlayerWin()
        {
            IsGameStarted = false;
            _menuManagerScript.ToggleWinPanel();
        }

        public void SetPlayerLoose()
        {
            IsGameStarted = false;
            _menuManagerScript.ToggleLoosePanel();
        }
    }
}
