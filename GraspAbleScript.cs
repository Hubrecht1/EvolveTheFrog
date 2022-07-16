using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


 

public class GraspAbleScript : MonoBehaviour
{
 
    [SerializeField] public SpriteRenderer SpriteR;
    [SerializeField] EnityManager EnityMan;
    StatsManager StatsMan;

    private void Start()
    {
        EnityMan = GameObject.FindGameObjectWithTag("EntityManger").GetComponent<EnityManager>();
        StatsMan = GameObject.Find("PlayerStats").GetComponent<StatsManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Player")
        {
            EnityMan.clockCount--;
            StatsMan.time_Years += Random.Range(1, 4); ;
            Destroy(this.gameObject);

        }
        else if(collision.gameObject.tag == "big collider")
        {
            EnityMan.clockCount--;
            Destroy(this.gameObject);

        }

    }



}


