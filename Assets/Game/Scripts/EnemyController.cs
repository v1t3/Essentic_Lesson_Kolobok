using System.Collections;
using UnityEngine;

//Work in process

namespace Game.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        private Rigidbody _rb;

        [SerializeField] private float movementSpeed = 1;
        [SerializeField] private float rotationSpeed = 1;
        [SerializeField] private float speedIsPlayerVisible = 1.5f;
        
        private AudioSource _walkAudioSource;

        private bool _moving = true;
        private bool _rotate;
        private bool _playerVisible;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _rb = GetComponent<Rigidbody>();
            _walkAudioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (!_gameManagerScript.IsGameStarted) return;

            if (_moving)
            {
                Move();
            }

            if (!_walkAudioSource.isPlaying)
            {
                _walkAudioSource.Play();
            }
        }

        private void Move()
        {
            float speed = _playerVisible ? speedIsPlayerVisible : movementSpeed;
            
            _rb.MovePosition(transform.position += transform.forward * speed * Time.fixedDeltaTime);

            var distanceForward = GetDistance(transform.forward, true);

            if (0 < distanceForward && 1 > distanceForward && !_playerVisible)
            {
                _moving = false;
                _rotate = true;

                float distanceRight = GetDistance(transform.right);
                //Округлить число до ближайшего числа кратному 90
                float correctedAngleY = Mathf.Round(transform.localRotation.eulerAngles.y / 90) * 90;
                //Направление
                float rotateAngle = (1 < distanceRight) ? 90 : -90;

                StartCoroutine(Rotate(correctedAngleY + rotateAngle));
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_gameManagerScript.IsGameStarted) return;

            if (other.gameObject.CompareTag("Player"))
            {
                _gameManagerScript.SetPlayerLoose();
            }
        }

        private float GetDistance(Vector3 direction, bool checkPlayer = false)
        {
            float result = 0;

            Vector3 rayPosition = transform.localPosition;
            rayPosition.y += transform.localScale.y / 2;
            Ray ray = new Ray(rayPosition, direction);
            
            Physics.Raycast(ray, out RaycastHit hit, 50);

            // Debug.DrawLine(ray.origin, hit.point, Color.red);
            
            if (hit.collider)
            {
                if (checkPlayer)
                {
                    _playerVisible = hit.collider.CompareTag("Player");
                }
                
                result = hit.distance;
            }

            return result;
        }

        private IEnumerator Rotate(float rotateAngle)
        {
            Quaternion lookAt = Quaternion.Euler(new Vector3(0, rotateAngle, 0));

            while (_rotate && transform.localRotation != lookAt)
            {
                transform.localRotation = Quaternion.RotateTowards(
                    transform.localRotation,
                    lookAt, 
                    rotationSpeed * 100 * Time.deltaTime
                );

                yield return new WaitForSeconds(0.01f);
            }

            _rotate = false;
            _moving = true;

            yield return null;
        }

        public void StopWalkSound()
        {
            _walkAudioSource.Stop();
        }
    }
}