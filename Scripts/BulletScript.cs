using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    void Update()
    {
        transform.position += transform.up * 4 * Time.deltaTime;
    }

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }



}
