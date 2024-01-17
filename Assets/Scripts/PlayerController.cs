using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Rigidbody bulletPrefab; // Assign your Bullet prefab in the inspector
    public float raycastDistance = 100f;
    
    [Header("Ref Mov")]
    [SerializeField] float speedMov = 5f;
     float movX;
    float movY;
    
    private void Awake() {
        player = GetComponent<Transform>();
    }
    void Update()
    {
        Move();
        RotateWithMouse();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Move(){
        player.Translate(Input.GetAxis("Horizontal") * speedMov * Time.deltaTime, 0, Input.GetAxis("Vertical") * speedMov * Time.deltaTime);
    }

    void RotateWithMouse(){
        movX += Input.GetAxis("Mouse X");
        player.rotation = Quaternion.Euler(player.rotation.y, movX, 0);
    }

    private void Shoot(){
         // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(bulletPrefab, transform.position , player.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        
        
       /*RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    // Instantiate the Bullet at the hit point, facing the same direction as the player
                    Instantiate(bulletPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }*/
    }
}
