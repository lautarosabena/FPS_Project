using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour
{
    public Rigidbody bullet;
    [SerializeField] private Transform _player;
    [SerializeField, Range(0.1f, 1000)] private float _bulletSpeed = 10f;
    [SerializeField, Range(1f, 100)] private int _bulletDamage = 1;
    void HacerUnRayo(){
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(rayo, out hit)){
            if(hit.transform.tag == "Player"){
            //GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(hit.normal));
            Rigidbody clone;
            clone = Instantiate(bullet, transform.position ,Quaternion.LookRotation(_player.position));
            /*Quaternion.Euler(hit.transform.rotation.eulerAngles.y +90, movX, 0)*/
            clone.velocity = transform.TransformDirection(Vector3.forward * _bulletSpeed);
            //_bullet.GetComponent<EnemyBullet>().SetForceAndDamage(_bulletSpeed, _bulletDamage);
            
            Debug.Log(hit.transform.name);}
        }
    }

    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot(){
        yield return new WaitForSeconds(1);
        HacerUnRayo();
    }
    
}
