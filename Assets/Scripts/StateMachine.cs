using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] PatrolState patrolState;
    [SerializeField] AttackState attackState;

    [SerializeField] Transform target;
    [SerializeField] float distanceToAttack = 15f;

    MonoBehaviour currentState;

    private void Update() {
        if(Vector3.Distance(transform.position, target.position) < distanceToAttack){
            Debug.Log("EstoyCerca");
            ChangeState(attackState);
        }
        else{
            ChangeState(patrolState);
        }
    }

    void ChangeState(MonoBehaviour newState){
        if(newState == currentState) return;
        if(currentState != null)  currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
    }
}
