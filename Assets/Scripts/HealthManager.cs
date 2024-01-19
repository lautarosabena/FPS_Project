using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public bool isAlive = true;
    [SerializeField] public float maxHP;
    [SerializeField] public float currentHP;
    public GameObject pantallaDerrota;


    private void Start()
    {
        isAlive = true;
        currentHP = maxHP;
    }

    private void Update()
    {
        if(!isAlive)
        {
            StartCoroutine(Die());
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
        CheckHP();
    }

    public IEnumerator Die()
    {
        pantallaDerrota.SetActive(true);
        Debug.Log("GAME OVER");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}
