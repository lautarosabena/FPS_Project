using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField ]private float _lifetime = 5f; 
    private float _force = 10f;
    private int _damageAmount; // Cantidad de daño infligido por la bala
    Vector2 startPos;
    [HideInInspector] public float angulo = 0f; // Ángulo de la trayectoria (en grados)
    [HideInInspector] public int side = 1;
    void Start() {
        _rb = GetComponent<Rigidbody>();
        // Destruir la bala después de un tiempo para evitar que se acumulen
        Destroy(gameObject, _lifetime);
    }

    public void SetForceAndDamage(float _force, int _damageAmount)
    {
        this._force = _force;
        this._damageAmount = _damageAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala colisiona con el jugador u otro objeto que tenga un script "HealthController"
        if(other.CompareTag("Enemy"))
        {
            EnemyHealthManager healthManager = FindObjectOfType<EnemyHealthManager>();
            healthManager.TakeDamage(_damageAmount);
        }

    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
