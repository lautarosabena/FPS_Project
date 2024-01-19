using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : MonoBehaviour
{
    [SerializeField] Transform[] targets;
    [SerializeField] private NavMeshAgent _agent;
    int indexCurrentTarget;
    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();        
    }
    private void Start() {
        ChangeTarget(indexCurrentTarget);
    }

    private void Update() {
        if(!_agent.hasPath){
            ChangeTarget(indexCurrentTarget);
        }
    }

    void ChangeTarget(int index){
        if(index >= targets.Length){
            indexCurrentTarget = 0;
        }
        _agent.SetDestination(targets[indexCurrentTarget].position);
        indexCurrentTarget++;
    }
    public void OnEnable() {
        _agent.isStopped = false;
    }

    public void OnDisable() {
        _agent.isStopped = true;

    }
}
