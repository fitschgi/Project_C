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
    
    bool playerTurn = true;
    bool enemyHit = false;
    public GameObject canvas;
    public GameObject player;
    public GameObject enemy;
    public GameObject presetButton;

    public Sprite buttonbg;
    //public Button attackButton;
    public List<Ability> attackList = new List<Ability>();

    public class Ability
    {
        public int damage;
        public string text;
        public Ability(int damage, string text)
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
        int i = 0;
        foreach (Ability ability in attackList)
        {
            /*
            Text presetText = (Text) preTextset.GetComponent(typeof(Text));
            GameObject buttonObject = new GameObject(ability.text);
            RectTransform trans = buttonObject.AddComponent<RectTransform>();
            Button button = buttonObject.AddComponent<Button>();
            Image image = buttonObject.AddComponent<Image>();
            
            GameObject text = new GameObject("text");
            Text tex = text.AddComponent<Text>();


            text.transform.SetParent(buttonObject.transform);
            tex.text = ability.text;
            tex.alignment = presetText.alignment;
            tex.font = presetText.font;
            tex.fontSize = presetText.fontSize;

            buttonObject.transform.SetParent(canvas.transform);

            trans.position = new Vector3(3 * i, 0, 0);
            trans.localScale = new Vector3(1f,2f,1f); 

            image.sprite = buttonbg;
            */
            GameObject buttonObject = GameObject.Instantiate(presetButton);
            buttonObject.transform.SetParent(canvas.transform);
            ((Text)buttonObject.GetComponentInChildren(typeof(Text))).text = ability.text;
            buttonObject.transform.position = presetButton.transform.position + new Vector3(3f * i, 0, 0);
            buttonObject.transform.localScale = new Vector3(1f,1f,1f);
            ((Button)buttonObject.GetComponent(typeof(Button))).onClick.AddListener(delegate{playerAttack(ability.damage);});
            i++;

            
        }
        //attackButton.onClick.AddListener(playerAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTurn && !enemyHit)
        {
            enemyHit= true;
            //yield return new WaitForSeconds(5);
            playerHealth -= 3;
            StartCoroutine(enemyAttackanim());
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

    void playerAttack(int damage)
    {
        if (playerTurn)
        {
            enemyHealth -= damage;
            StartCoroutine(playerAttackanim());
        }
    }
    //only testing gonna get removed
     IEnumerator playerAttackanim()
    {
        for(int i = 0; i<12; i++){
            player.transform.position += new Vector3(1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        } 
        yield return new WaitForSeconds(0.5f);
        player.transform.position += new Vector3(-12f, 0, 0);
        yield return new WaitForSeconds(1f);

        playerTurn = false;
        enemyHit = false;
    }
    
      IEnumerator enemyAttackanim()
    {
         for(int i = 0; i<12; i++){
            enemy.transform.position += new Vector3(-1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        } 
        yield return new WaitForSeconds(0.5f);
        enemy.transform.position += new Vector3(12f, 0, 0);
        yield return new WaitForSeconds(1f);





        playerTurn = true;
    }
}
