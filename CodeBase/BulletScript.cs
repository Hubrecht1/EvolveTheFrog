using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    StatsManager PlayerStats;
    [SerializeField] AudioSource gunShot;
    [SerializeField] SpriteRenderer SpriteRen;
    void Update()
    {
        transform.position += transform.up * 4 * Time.deltaTime;
        
    }

    private void Awake()
    {
        SpriteRen.enabled = true;
        PlayerStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<StatsManager>();
        gunShot.Play();
        Destroy(gameObject, 1.5f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats.health--;
        SpriteRen.enabled = false;
       
        

    }



}
