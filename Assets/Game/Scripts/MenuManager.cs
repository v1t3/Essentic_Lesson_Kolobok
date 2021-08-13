using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        private CoinManager _coinManagerScript;
        
        [SerializeField] private GameObject _helloPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _coinCountField;

        private Text _coinCountText;

        private void Awake()
        {
            _coinManagerScript = FindObjectOfType<CoinManager>();
            _coinCountText = _coinCountField.GetComponent<Text>();
        }

        private void FixedUpdate()
        {
            _coinCountText.text = "Монетки: " + _coinManagerScript.GetCollectedCoinsCount();
        }

        public void ShowInterface()
        {
            _coinCountField.SetActive(true);
            ToggleHelloPanel();
        }

        public void ToggleHelloPanel()
        {
            _helloPanel.SetActive(!_helloPanel.activeSelf);
        }

        public void ToggleWinPanel()
        {
            _winPanel.SetActive(!_winPanel.activeSelf);
        }
    }
}
