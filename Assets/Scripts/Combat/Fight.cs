using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    //variables
    public int playerHealth;
    public int enemyHealth;
    public bool playerTurn;

    public GameObject player;
    public GameObject enemy;
    public Button attackButton;

    // Start is called before the first frame update
    void Start()
    {
        /* 
        playerHealth = 100;
        enemyHealth = 100;
        playerTurn = true; 
        */
        attackButton.onClick.AddListener(playerAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTurn)
        {
            playerHealth -= 3;
            playerTurn = true;
            Debug.Log(playerHealth);
            Debug.Log(enemyHealth);
        }
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
        }
        if (enemyHealth <= 0)
        {
            Debug.Log("You Win");
        }
    }

    void playerAttack()
    {
        if (playerTurn)
        {
            enemyHealth -= 10;
            playerTurn = false;
        }
    }
}
