using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private CoinManager _coinManagerScript;
        
        private MenuManager _menuManagerScript;
        
        public bool isGameStarted;

        private void Awake()
        {
            _coinManagerScript = FindObjectOfType<CoinManager>();
            _menuManagerScript = FindObjectOfType<MenuManager>();
        }

        private void Start()
        {
            isGameStarted = false;
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
            isGameStarted = true;
            _menuManagerScript.ToggleHelloPanel();
            _coinManagerScript.EnableCoins();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StopGame()
        {
            Debug.Log("Quit");
            isGameStarted = false;
            Application.Quit();
        }

        public void SetPlayerWin()
        {
            isGameStarted = false;
            _menuManagerScript.ToggleWinPanel();
        }

        public void SetPlayerLoose()
        {
            isGameStarted = false;
            _menuManagerScript.ToggleLoosePanel();
        }
    }
}
