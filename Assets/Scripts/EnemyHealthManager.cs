using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthManager : MonoBehaviour
{
    public bool isAlive = true;
    [SerializeField] private float _maxHP = 10;
    [SerializeField] public float currentHP;
    public AudioSource hitSFX;



    private void Start()
    {
        isAlive = true;
        currentHP = _maxHP;
    }

    private void Update()
    {
        if(!isAlive)
        {
            Die();
        }
    }

    void CheckHP()
    {
        if (currentHP <= 0)
        {
            isAlive = false;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        hitSFX.Play();
        CheckHP();
        Debug.Log(this.gameObject + " took " + damage + " damage");
    }

    public void Die()
    {
        Debug.Log(this.gameObject + " died");
        Destroy(gameObject);
    }
}
