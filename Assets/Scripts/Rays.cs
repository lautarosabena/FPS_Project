using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour
{
    public Rigidbody bullet;
    Color colorRay = Color.red;
    [SerializeField] private Transform _player;
    [SerializeField, Range(0.1f, 1000)] private float _bulletSpeed = 10f;
    [SerializeField, Range(1f, 100)] private int _bulletDamage = 1;
    private float timer;
    public float shootInterval = 0.4f;
    public bool canShoot = true;
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void HacerUnRayo(){
        Ray rayo = new Ray(transform.position + new Vector3(0,1.3f,0), transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(rayo, out hit)){
            if(hit.transform.tag == "Player"){
            colorRay = Color.green;
            StartCoroutine(Shoot());
            /*Rigidbody clone;
            clone = Instantiate(bullet, transform.position + new Vector3(0,1.3f,0) ,Quaternion.LookRotation(_player.position));
            clone.velocity = transform.TransformDirection(Vector3.forward * _bulletSpeed);  */          
            Debug.Log(hit.transform.name);
            }
            else{
                colorRay = Color.red;
            }
        }
        Debug.DrawRay(rayo.origin, rayo.direction * 100, colorRay);
    }

    void Update()
    {
        //transform.Rotate(0, 20 * Time.deltaTime, 0);
        HacerUnRayo();
    }

    public IEnumerator Shoot()
    {
        if(canShoot){
        Rigidbody clone;
        clone = Instantiate(bullet, transform.position + new Vector3(0,1.3f,0) ,Quaternion.LookRotation(_player.position));
        clone.velocity = transform.TransformDirection(Vector3.forward * _bulletSpeed);
        _anim.SetTrigger("shoot");
        canShoot = false;
        }
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
        Debug.Log("Dispare");
    }
    
    
}
