using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private CoinManager _coinManagerScript;
        private MenuManager _menuManager;
        
        public bool isGameStarted;

        private void Awake()
        {
            _coinManagerScript = FindObjectOfType<CoinManager>();
            _menuManager = FindObjectOfType<MenuManager>();
        }

        private void Start()
        {
            _menuManager.ShowInterface();
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
            isGameStarted = true;
            _menuManager.ToggleHelloPanel();
            _coinManagerScript.EnableCoins();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StopGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        public void SetPlayerWin()
        {
            isGameStarted = false;
            _menuManager.ToggleWinPanel();
        }
    }
}
