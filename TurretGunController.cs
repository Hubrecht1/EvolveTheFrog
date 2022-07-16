using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    bool shoot = true;
    Vector3 originalPosition;
    float t;


    float turnRate = 200;
    private void Awake()
    {
     
    }

    IEnumerator FireBullets()
   {
        originalPosition = transform.position;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(0.1f);
            float yoffset = Random.Range(-0.1f, 0.1f);
            float xoffset = Random.Range(-0.1f, 0.1f);
            
            Instantiate(bullet, new Vector3(transform.position.x + xoffset, transform.position.y + yoffset, 0), Quaternion.Euler(new Vector3(0, 0, transform.localEulerAngles.z + 90)));
            transform.position -= -transform.right * 0.02f;

        }
        
        yield return new WaitForSeconds(1f);

        
        shoot = true;
    }

    private void Update()
    {
        if (transform.position != originalPosition && shoot == false)
        {
            t += Time.deltaTime / 100f;
            transform.position = Vector3.Lerp(transform.position, originalPosition, t);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {  
        if (shoot == true)
        {
            
            shoot = false;
            StartCoroutine("FireBullets");
        }
        
        float angle = Mathf.Atan2(collision.transform.position.y - transform.position.y, collision.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle+180));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "big collider")
        {

        }
    }





}
