using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Rigidbody bulletPrefab; // Assign your Bullet prefab in the inspector
    public float raycastDistance = 100f;
    private Animator _anim;
    public AudioSource shootSFX;
    public AudioSource runSFX;
    public bool isMoving = false;
    
    [Header("Ref Mov")]
    [SerializeField] float speedMov = 5f;
     float movX;
    float movY;
    
    private void Awake() {
        player = GetComponent<Transform>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        RotateWithMouse();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if(!isMoving){
        runSFX.Play();}
    }

    private void Move(){
        player.Translate(Input.GetAxis("Horizontal") * speedMov * Time.deltaTime, 0, Input.GetAxis("Vertical") * speedMov * Time.deltaTime);
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
        _anim.SetTrigger("Walk");
        isMoving = true;

        }else{
            _anim.SetTrigger("Idle");
            isMoving = false;
        }
    }

    void RotateWithMouse(){
        movX += Input.GetAxis("Mouse X");
        player.rotation = Quaternion.Euler(player.rotation.y, movX, 0);
    }

    private void Shoot(){
         // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(bulletPrefab, transform.position + new Vector3(-0.2F,1.3f,0) , Quaternion.Euler(player.rotation.y +90, movX, 0));
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            shootSFX.Play();
        
        
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
