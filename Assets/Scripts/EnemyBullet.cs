using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerController _player;
    [SerializeField ]private float _lifetime = 5f; 
    private float _force = 10f;
    private int _damageAmount; // Cantidad de daño infligido por la bala
    Vector2 startPos;
    void Start() {
        _rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        _player = FindObjectOfType<PlayerController>();

        // Calcular la dirección en función del ángulo
        Vector3 dir = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);

        // Aplicar la velocidad a la dirección
       _rb.velocity = dir * _force;
        
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
        if(other.CompareTag("Player"))
        {
            HealthManager healthManager = FindObjectOfType<HealthManager>();
            healthManager.TakeDamage(_damageAmount);
        }

    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
