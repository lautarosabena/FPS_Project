using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] List<EnemyController> enemyPool;

    private void Awake() {
        foreach (var enemy in enemyPool)
        {
            enemy.gameObject.SetActive(false);
        }
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           EnemyController newEnemy = GetOneEnemy();
            newEnemy.pool = this;
        }
    }

    public EnemyController GetOneEnemy()
    {
        foreach (EnemyController enemy in enemyPool)
        {
            if(!enemy.gameObject.activeInHierarchy)
            {
                enemy.gameObject.SetActive(true);
                enemy.transform.SetParent(null);
                return enemy;
            }
        }

        EnemyController _newEnemy = Instantiate(enemyPrefab);
        _newEnemy.gameObject.SetActive(true);
        _newEnemy.pool = this;
        enemyPool.Add(_newEnemy);
        return _newEnemy;
    }
}
