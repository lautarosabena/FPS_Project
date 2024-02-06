using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    private Animator _anim;
    public PoolManager pool;
    private Transform _player;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>(); 
        _anim = GetComponent<Animator>();  
        _player = GameObject.Find("Player").transform;
    }
    private void Update() {
        _agent.SetDestination(_player.position);
        if(_agent.velocity != Vector3.zero){
            _anim.SetTrigger("walk");
        }else{
            _anim.SetTrigger("idle");
        }
    }
}
