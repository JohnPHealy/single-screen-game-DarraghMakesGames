using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour

   
{

    private int enemyNumber;
    [SerializeField] private UnityEvent allEnemiesKilled;
    [SerializeField] private UnityEvent<string> updateEnemiesRemaining;

    void Start()
    {
        enemyNumber = 4;
        updateUI();
    }



    public void EnemyKilled()
    {
        enemyNumber--;
        updateUI();
    }

    private void Update()
    {
        if (enemyNumber < 1)
        {
            allEnemiesKilled.Invoke();
        }
    }


    private void updateUI()
    {
        updateEnemiesRemaining.Invoke(enemyNumber.ToString());
    }

}
