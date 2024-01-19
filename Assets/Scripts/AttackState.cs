using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    [SerializeField] private float _rateFire = 0.4f;
    [SerializeField] private Transform _player;
    public Rigidbody bullet;
    private Animator _anim;
    float timeToFire;

    private void Awake() {
        _anim = GetComponent<Animator>();
    }
    private void Update() {
        timeToFire += Time.deltaTime;

        if(timeToFire > _rateFire){
            Attack();
            timeToFire = 0;
        }
    }

    void Attack(){
        Debug.Log("Atacando");
        Rigidbody clone;
        clone = Instantiate(bullet, transform.position + new Vector3(0,1.3f,0) ,Quaternion.identity);
        Vector3 direction = (_player.position - transform.position).normalized;
        clone.velocity = direction * 10;
        _anim.SetTrigger("shoot");
    }
}
