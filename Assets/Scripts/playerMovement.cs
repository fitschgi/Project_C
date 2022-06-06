using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMovement : MonoBehaviour
{
    
    public float speed = 12;
    public bool movement = true;
    private Collider2D collider;
    public TextBox boxi;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(movement)
            transform.Translate(Input.GetButton("Vertical") ? (float) (Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime / Math.Sqrt(2)) : (float) (Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime), Input.GetButton("Horizontal") ? (float)(Input.GetAxis("Vertical") / Math.Sqrt(2) *speed * Time.fixedDeltaTime): (float)(Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime), 0);
        if(Input.GetButton("Jump")){
            boxi.disableTextBox();
            GetComponent<Cutscene>().Running = false;

        }
            
    }
}
