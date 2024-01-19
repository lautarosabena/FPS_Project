using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] soldiersInScene;
    private EnemyHealthManager soldierHealthManager;
    public GameObject pantallaVictoria;
    public GameObject player;
    private bool _isAlive;
    public float soldiersMurdered = 0;
    private bool[] _doOnce;

    private void Start()
    {
        Time.timeScale = 1;
        _doOnce = new bool[soldiersInScene.Length];
        for (int i = 0; i < _doOnce.Length; i++)
        {
            _doOnce[i] = true;
        }
    }

    private void Update()
    {
        CheckIfIsAlive();
        if (soldiersMurdered == soldiersInScene.Length)
        {
            StartCoroutine(Win());
        }        
    }

    private void CheckIfIsAlive()
    {
        for (int i = 0; i < soldiersInScene.Length; i++)
        {
            var _soldier = soldiersInScene[i];
            try
            {
                soldierHealthManager = _soldier.GetComponent<EnemyHealthManager>();
                _isAlive = soldierHealthManager.isAlive;
                if (!_isAlive && _doOnce[i])
                {
                    soldiersMurdered++;
                    _doOnce[i] = false;
                    return;
                }

            }catch(System.Exception)
            {
                if (_doOnce[i])
                {
                    soldiersMurdered++;
                    _doOnce[i] = false;
                    return;
                }
            }

        }
    }

    public IEnumerator Win(){
        pantallaVictoria.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(player);
        Time.timeScale = 0;

    }
}
