using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public bool Running = false;
    private int progress;
    private float distance;
    private float xMove = 0;
    private float yMove = 0;
    // Start is called before the first frame update
    public void startCutscene(){
        Running = true;
        GetComponent<Collider2D>().enabled = false;
    }
    public void stopCutscene(){
        Running = false;
        GetComponent<Collider2D>().enabled = true;
    }
    public void moveToTarget(float x, float y, int time){
        if(Running){
            progress = 0;
            float xCurr = transform.position.x;
            float yCurr = transform.position.y;
            xMove = (Time.fixedDeltaTime * (x - xCurr)) / time;
            yMove = (Time.fixedDeltaTime * (y - yCurr)) / time;
            distance = time / Time.fixedDeltaTime;
            Debug.Log(x);
            Debug.Log(y);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate(){
         if(Running && progress < distance){
            transform.Translate(xMove, yMove, 0);

            progress++;
        }
    }
}
