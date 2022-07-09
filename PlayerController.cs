using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    public Animator animator;
    [SerializeField] StatsManager stats;
    [SerializeField] EnityManager EntityMana;


    private void Start()
    {
        playerSpeed = stats.speed;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Speed", 1f);
            transform.position += new Vector3(playerSpeed * Time.deltaTime,0f,0f);

        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("Speed", 1f);
            transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0f, 0f);

        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Speed", 1f);
            transform.position += new Vector3(0, playerSpeed * Time.deltaTime, 0f);

        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("Speed", 1f);
            transform.position += new Vector3(0, -playerSpeed * Time.deltaTime, 0f);

        }

        if(Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            animator.SetFloat("Speed", 0f);
        }
    }


  
   







}
