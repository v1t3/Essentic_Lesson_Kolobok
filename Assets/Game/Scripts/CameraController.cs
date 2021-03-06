using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        [SerializeField] private GameObject player;

        private Rigidbody _playerRb;

        [SerializeField] private float rotationSpeed;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _playerRb = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_gameManagerScript.IsGameStarted) return;

            float yRotation = Input.GetAxis("Mouse X");
            transform.Rotate(0, yRotation * rotationSpeed * Time.deltaTime, 0);
        }

        private void LateUpdate()
        {
            transform.position = _playerRb.transform.position;
        }
    }
}
