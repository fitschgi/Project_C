using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCollision : MonoBehaviour
{
    public TextBox boxi;
    public Cutscene movi;
    public playerMovement popi;
    bool enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(sceneName:"Combat");
        /* 
        if (enabled)
        boxi.displayTextBox("Hello Fellow traveller, cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.cum.", 2);
        enabled = false;
        */
    }
}
