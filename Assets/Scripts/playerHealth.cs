using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video;
    public Camera camera;
    public GameObject canvas;
    public GameObject anchor;
    public int currentHealth;
    public Sprite heart;
    public List<GameObject> hearts = new List<GameObject>();  
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {  
        if(currentHealth <1){
            currentHealth = 0;
            video.Play();
            StartCoroutine(destroy());
        }
        for(int i = hearts.Count; i < currentHealth; i++){
        GameObject imgObject = new GameObject("heart" + i);
    
        RectTransform trans = imgObject.AddComponent<RectTransform>();
        

        Image image = imgObject.AddComponent<Image>();
        image.sprite = heart;
        imgObject.transform.SetParent(canvas.transform);
        trans.position = anchor.transform.position + new Vector3(0 + 1 * i, 0, 0);
        trans.localScale = new Vector3(0.3f,0.3f,1f);
        hearts.Add(imgObject);
        canvas.GetComponent<Canvas>().enabled = true;
        }
        int counter = hearts.Count - currentHealth;
        for(int i = 0; i < counter ; i++){
       
            Destroy(hearts[hearts.Count -1]);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(6);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
        
}
