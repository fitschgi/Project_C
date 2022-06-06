using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    private string twetxs = "";
    public Camera camera;
    private bool writing = false;
    private int index = 0;
    public int speed;
    public Text text;
    public Image box;
    public playerMovement player;
    public void displayTextBox(string text, int time){
        camera.orthographicSize = 2;
        this.speed = time * 1000 / text.Length;
        player.movement = false;
        box.GetComponent<Image>().enabled = true;
        this.twetxs = text;
        writing = true;
        index = 0;
    }
    public void disableTextBox(){
        camera.orthographicSize = 8;
        player.movement = true;
        box.GetComponent<Image>().enabled = false;
        this.text.text = "";
        twetxs = "";
        writing = false;
        index = 0;
    }
    // Start is called before the first frame update
    void Start()
    {   
        this.text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(index == twetxs.Length) writing = false;
        if(writing){
            this.text.text += twetxs[index];
            index++;
            System.Threading.Thread.Sleep(speed);
        }
    }
}
