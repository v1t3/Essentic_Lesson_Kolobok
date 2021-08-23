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

        private bool _moving = true;
        private bool _rotate;
        private bool _playerVisible;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (!_gameManagerScript.isGameStarted) return;

            if (_moving)
            {
                float speed = _playerVisible ? speedIsPlayerVisible : movementSpeed;
                
                _rb.MovePosition(transform.position += transform.forward * speed * Time.deltaTime);

                var distanceForward = GetDistance(transform.forward, true);

                if (0 < distanceForward && 1 > distanceForward && !_playerVisible)
                {
                    _moving = false;
                    _rotate = true;

                    float distanceRight = GetDistance(transform.right);

                    if (1 < distanceRight)
                    {
                        StartCoroutine(Rotate(transform.localRotation.eulerAngles.y + 90));
                    }
                    else
                    {
                        StartCoroutine(Rotate(transform.localRotation.eulerAngles.y - 90));
                    }
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_gameManagerScript.isGameStarted) return;

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
    }
}