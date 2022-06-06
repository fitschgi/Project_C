using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    //Abilities

    public class Ability {
        public int damage;
    }
    Ability Punch;
    Ability Scratch;


    // Start is called before the first frame update
    void Start()
    {
        Punch.damage = 30;
        Scratch.damage = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
