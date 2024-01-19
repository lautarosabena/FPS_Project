using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerController _player;
    [SerializeField ]private float _lifetime = 5f; 
    private float _force = 10f;
    private int _damageAmount = 1;
    Vector2 startPos;
    void Start() {
        _rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        _player = FindObjectOfType<PlayerController>();
        Destroy(gameObject, _lifetime);
    }

    public void SetForceAndDamage(float _force, int _damageAmount)
    {
        this._force = _force;
        this._damageAmount = _damageAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HealthManager healthManager = FindObjectOfType<HealthManager>();
            healthManager.TakeDamage(_damageAmount);
            Debug.Log("El jugador ha recibido " + _damageAmount + " puntos de daño. Le quedan " + healthManager.currentHP + " puntos de vida.");
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
