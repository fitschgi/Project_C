using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFollowOnSee : MonoBehaviour
{
    //Necessary variables
    public int viewDistance;
    public int speed;
    public bool ReturnToSpotAfterLosingVision;
    public bool ShowDebugLines;
    public GameObject player;

    private float randomDirectionx = 1;
    private float randomDirectiony = 1;
    private float startx;
    private float starty;
    private int randomCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        startx = transform.position.x;
        starty = transform.position.y;  

    }
    void runToPlayer(){
        randomCounter = 0;
        Transform playe = player.GetComponent<Transform>();
        float diffx = playe.position.x - transform.position.x;
        float diffy = playe.position.y - transform.position.y;
        float xmult = diffx < 0 ? -1 : 1;
        float ymult = diffy < 0 ? -1 : 1;
        float k = Math.Abs(diffx / diffy);
        float ly = (float)(speed / (Math.Sqrt(1+(k*k))));
        float lx = ly *k;
        transform.Translate(lx * Time.fixedDeltaTime* xmult, ly * Time.fixedDeltaTime * ymult, 0);
    }
    void runAround(){
        System.Random rd = new System.Random();
        if(randomCounter >= 10){
            
            randomDirectionx = (float)rd.Next(-100,101) / 100;
            randomDirectiony = (float)rd.Next(-100,101) / 100;

            randomCounter = 0;
        }

        transform.Translate(1 * Time.fixedDeltaTime * randomDirectionx, 1 * Time.fixedDeltaTime * randomDirectiony, 0 );
    }
    void returnToSpot(){
        if(Math.Abs(transform.position.x - startx) < 0.1 && Math.Abs(transform.position.y - starty)< 0.1) randomCounter = 0;
        if(randomCounter >= 120){
            float diffx = startx - transform.position.x;
            float diffy = starty - transform.position.y;
            float xmult = diffx < 0 ? -1 : 1;
            float ymult = diffy < 0 ? -1 : 1;
            float k = Math.Abs(diffx / diffy);
            float ly = (float)(speed / (Math.Sqrt(1+(k*k))));
            float lx = ly *k;
            transform.Translate(lx * Time.fixedDeltaTime* xmult, ly * Time.fixedDeltaTime * ymult, 0);
        }
    }
    void OnDrawGizmos(){
        if(!ShowDebugLines)return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag != "Player") return;
        player.GetComponent<playerHealth>().currentHealth--;
        Transform playe = player.GetComponent<Transform>();
        float diffx = playe.position.x - transform.position.x;
        float diffy = playe.position.y - transform.position.y;
        float xmult = diffx < 0 ? -1 : 1;
        float ymult = diffy < 0 ? -1 : 1;
        float k = Math.Abs(diffx / diffy);
        float ly = (float)(speed / (Math.Sqrt(1+(k*k))));
        float lx = ly *k;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector3(lx * xmult* 5, ly * ymult* 5, 0) , ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(-lx * xmult* 5, -ly * ymult* 5, 0) , ForceMode2D.Impulse);
        StartCoroutine(sizeback(viewDistance));
        viewDistance = 0;
    }
       IEnumerator sizeback(int viewDistanc)
    {
        yield return new WaitForSeconds(1);
        viewDistance = viewDistanc;
    }
        
    // Update is called once per frame
    void FixedUpdate()
    {
        Transform playe = player.GetComponent<Transform>();
        //Checks if player is in viewing distance using the pythagorean theorem
        if(Math.Sqrt((transform.position.x - playe.position.x)*(transform.position.x - playe.position.x) + (transform.position.y - playe.position.y)*(transform.position.y - playe.position.y)) <= viewDistance){
            runToPlayer();
        }else{
            randomCounter++;
            //Either run around or return to spot when losing vision
            if(ReturnToSpotAfterLosingVision){
                returnToSpot();
            }else{
                runAround();
            }




        }
    }
}
