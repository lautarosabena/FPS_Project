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
    public float fireRate = 0.4f;
    float timeToFire = 0;
    public bool canShoot = true;
    private Animator _anim;
    [SerializeField, Range(1, 360)] private int fieldOfView = 90;
    [SerializeField, Range(1, 100)] private int numberOfRays = 10;
    public float rotationAngle;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void HacerUnRayo1(){
        Ray rayo = new Ray(transform.position + new Vector3(0,1.3f,0), transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(rayo, out hit)){
            if(hit.transform.tag == "Player"){
            colorRay = Color.green;
            Shoot();        
            Debug.Log(hit.transform.name);
            }
            else{
                colorRay = Color.red;
            }
        }
        Debug.DrawRay(rayo.origin, rayo.direction * 100, colorRay);
    }
    void HacerUnRayo()
{
    float stepAngleSize = fieldOfView / numberOfRays;
    for (int i = 0; i <= numberOfRays; i++)
    {
        float angle = transform.eulerAngles.y - fieldOfView / 2 + stepAngleSize * i;
        Vector3 dir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        Ray rayo = new Ray(transform.position + new Vector3(0,1.3f,0), dir);
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                colorRay = Color.green;
                if(timeToFire > fireRate){
                    Shoot();
                    timeToFire = 0;
                }
                Debug.Log("Estoy viendo a: " + hit.transform.name);
            }
            else
            {
                colorRay = Color.red;
            }
        }
        Debug.DrawRay(rayo.origin, rayo.direction * 100, colorRay);
    }
}

    void Update()
    {
        timeToFire += Time.deltaTime;
        transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
        HacerUnRayo();
    }

    public void Shoot()
    {
        Rigidbody clone;
        clone = Instantiate(bullet, transform.position + new Vector3(0,1.3f,0) ,Quaternion.LookRotation(_player.position));
        Vector3 direction = (_player.position - transform.position).normalized;
        clone.velocity = direction * 10;
        _anim.SetTrigger("shoot");        
        Debug.Log("Dispare");
    }
    
    
}
