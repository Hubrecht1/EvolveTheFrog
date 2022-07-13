using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


 

public class GraspAbleScript : MonoBehaviour
{
 
    [SerializeField] public SpriteRenderer SpriteR;
    [SerializeField] EnityManager EnityMan;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "big collider")
        {
            EnityMan = GameObject.FindGameObjectWithTag("EntityManger").GetComponent<EnityManager>();

            EnityMan.clockCount--;
            Destroy(this.gameObject); 
        }

    }



}


