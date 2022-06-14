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
    public GameObject canvas;

    public GameObject player;
    public GameObject enemy;
    //public Button attackButton;
    public List<Ability> attackList = new List<Ability>();

    public class Ability
    {
        public int damage;
        public string text;
        public Ability(int damage, string text,)
        {
            this.damage = damage;
            this.text = text;
        }
    }
    Ability Punch = new Ability(10, "Punch");
    Ability Scratch = new Ability(8, "Scratch");
    Ability Lick = new Ability(1, "Lick");

    // Start is called before the first frame update
    void Start()
    {
        attackList.Add(Punch);
        attackList.Add(Scratch);
        attackList.Add(Lick);
        foreach (Ability ability in attackList)
        {
            GameObject buttonObject = new GameObject(ability.text);
            RectTransform trans = buttonObject.AddComponent<RectTransform>();
            buttonObject.transform.SetParent(canvas.transform);
            Button button = buttonObject.AddComponent<Button>();
            button.onClick.AddListener(playerAttack);
        }
        //attackButton.onClick.AddListener(playerAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTurn)
        {
            //yield return new WaitForSeconds(5);
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
            SceneManager.LoadScene(sceneName: "SampleScene");
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
