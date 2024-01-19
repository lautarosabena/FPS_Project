using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    private Animator _anim;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>(); 
        _anim = GetComponent<Animator>();       
    }
    private void Update() {
        _agent.SetDestination(_target.position);
        if(_agent.velocity != Vector3.zero){
            _anim.SetTrigger("walk");
        }else{
            _anim.SetTrigger("idle");
        }
    }
}
