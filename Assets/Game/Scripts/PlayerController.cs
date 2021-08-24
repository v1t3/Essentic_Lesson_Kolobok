using System;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        
        private Camera _camera;

        private Rigidbody _playerRb;

        [SerializeField] private float speedNormal;
        [SerializeField] private float speedExtra;
        [SerializeField] private float topSpeed = 10;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _camera = FindObjectOfType<Camera>();
            _playerRb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_gameManagerScript.IsGameStarted) return;
            
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            float speed = Input.GetKeyDown(KeyCode.LeftShift) ? speedNormal * speedExtra : speedNormal;
        
            if (0 != vertical || 0 != horizontal)
            {
                var cameraTransform = _camera.transform;
                var direction = cameraTransform.forward * vertical +  cameraTransform.right * horizontal;
                direction.y = 0;
                _playerRb.AddForce(direction * speed * Time.deltaTime, ForceMode.VelocityChange);
            }

            // Player max speed
            if (_playerRb.velocity.magnitude > topSpeed)
            {
                _playerRb.velocity = _playerRb.velocity.normalized * topSpeed;
            }
        }
    }
}
