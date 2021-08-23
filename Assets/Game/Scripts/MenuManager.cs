using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        private CoinManager _coinManagerScript;
        
        [SerializeField] private GameObject helloPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject loosePanel;
        [SerializeField] private GameObject coinCountField;

        private Text _coinCountText;

        private void Awake()
        {
            _coinManagerScript = FindObjectOfType<CoinManager>();
            _coinCountText = coinCountField.GetComponent<Text>();
        }

        public void ShowInterface()
        {
            coinCountField.SetActive(true);
            ToggleHelloPanel();
        }

        public void ToggleHelloPanel()
        {
            helloPanel.SetActive(!helloPanel.activeSelf);
        }

        public void ToggleWinPanel()
        {
            winPanel.SetActive(!winPanel.activeSelf);
        }

        public void ToggleLoosePanel()
        {
            loosePanel.SetActive(!loosePanel.activeSelf);
        }

        public void UpdateCoinCountText()
        {
            _coinCountText.text = "Монетки: " + _coinManagerScript.CoinsCollected.ToString()
                                              + "/" + _coinManagerScript.CoinCountStart.ToString();
        }
    }
}
