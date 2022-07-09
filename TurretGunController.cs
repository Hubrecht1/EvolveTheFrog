using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : MonoBehaviour
{
    PlayerController _Player;
    float turnRate = 100;

    public void OnSpawn()
    {
        //_Player = GameObject.FindGameObjectWithTag("_Player").GetComponent<PlayerController>();
        
        
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        float angle = Mathf.Atan2(collision.transform.position.y - transform.position.y, collision.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle+180));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate * Time.deltaTime);
    }
}
