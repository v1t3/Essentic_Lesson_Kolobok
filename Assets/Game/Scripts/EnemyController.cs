using System;
using System.Collections;
using UnityEngine;

//Work in process

namespace Game.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private float rotationSpeed = 10;

        private bool _moving;
        private bool _rotate;

        private void Start()
        {
            _moving = true;
        }

        private void Update()
        {
            // if (_moving)
            // {
            //     // Debug.Log("forward: " + transform.forward);
            //     
            //     transform.Translate(new Vector3(0,0,transform.localPosition.z) * speed * Time.deltaTime);
            //
            //     Ray ray = new Ray(transform.position, transform.forward);
            //     RaycastHit hit;
            //     Physics.Raycast(ray, out hit, 50);
            //
            //     if (hit.collider)
            //     {
            //         Debug.Log("distance: " + hit.distance);
            //         // Debug.Log("tag: " + hit.collider.tag);
            //         Debug.DrawLine(ray.origin, hit.point, Color.red);
            //
            //         if (1 > hit.distance)
            //         {
            //             // ChangeDirection();
            //             _moving = false;
            //             _rotate = true;
            //         }
            //     }
            // }
            //
            // if (_rotate)
            // {
            //     // Debug.Log("rotation y: " + transform.rotation.eulerAngles.y);
            //     if (transform.rotation.eulerAngles.y < 90)
            //     {
            //         transform.rotation = Quaternion.RotateTowards(
            //             transform.rotation,
            //             Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0),
            //             Time.deltaTime * rotationSpeed
            //         );
            //     }
            //     else
            //     {
            //         _rotate = false;
            //         _moving = true;
            //     }
            // }
        }
    }
}
