using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public TextBox boxi;
    public Cutscene playerw;
    public playerMovement popi;
    public Cutscene npc;
    bool enabled = true;
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
        if(enabled){
            playerw.startCutscene();
            popi.movement = false;
            npc.startCutscene();
            npc.moveToTarget(transform.position.x + 3, transform.position.y, 5);
            StartCoroutine(textiboxi());
            enabled = false;
        }
        
        
    }
    IEnumerator textiboxi()
    {
        yield return new WaitForSeconds(5);
        boxi.displayTextBox("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad ", 5);
        yield return new WaitForSeconds(8);
        npc.stopCutscene();
        playerw.stopCutscene();
        boxi.disableTextBox();
    }
}
