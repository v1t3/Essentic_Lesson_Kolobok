using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        private GameObject _player;

        private Rigidbody _playerRb;

        [SerializeField] private float rotationSpeed;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _player = FindObjectOfType<PlayerController>().gameObject;
            _playerRb = _player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_gameManagerScript.isGameStarted) return;

            float yRotation = Input.GetAxis("Mouse X");
            transform.Rotate(0, yRotation * rotationSpeed * Time.deltaTime, 0);
        }

        private void LateUpdate()
        {
            transform.position = _playerRb.transform.position;
        }
    }
}
