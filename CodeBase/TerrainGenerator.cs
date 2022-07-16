using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private BoxCollider2D _BoxCollider;
    private bool playerCollision = false;
    private Transform thisobject;
    bool NewObject = true;

    GameObject CurrentPlayer;
    GameObject BigCollider;
    GameObject MediumCollider;
    GameObject SmallCollider;

    [SerializeField] float distance;
    [SerializeField] EnityManager EnityMan;
    [SerializeField] StatsManager StatsMan;
    
    private IEnumerator Start()
    {
        
        _BoxCollider = GetComponent<BoxCollider2D>();
        thisobject = GameObject.Find("Terrain").transform;
        
        playerCollision = false;
        NewObject = true;
        yield return new WaitForSeconds(0.5f);
        NewObject = false;
    }

    public void OnEvolve()
    {
        CurrentPlayer = StatsMan.CurrentPlayerClone;
        BigCollider = CurrentPlayer.transform.Find("BigCollider").gameObject;
        MediumCollider = CurrentPlayer.transform.Find("MediumCollider").gameObject;
        SmallCollider = CurrentPlayer.transform.Find("SmallCollider").gameObject;

    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GeneratePlainTerrain();
        }
      

    }

    void GeneratePlainTerrain()
    {
        GameObject clone;
        

        if (DoesOverlap(Vector3.up) == false)
        {
            
            //draw top
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y + _BoxCollider.bounds.size.y + distance, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;
            //draw top corners
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x + _BoxCollider.bounds.size.x + distance, transform.position.y + _BoxCollider.bounds.size.y + distance, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x - _BoxCollider.bounds.size.x - distance, transform.position.y + _BoxCollider.bounds.size.y + distance, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;

        }
        if (DoesOverlap(Vector3.down) == false)
        {
            
            //draw buttom corners
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x + _BoxCollider.bounds.size.x + distance, transform.position.y - _BoxCollider.bounds.size.y - distance, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;

            clone = Instantiate(this.gameObject, new Vector3(transform.position.x - _BoxCollider.bounds.size.x - distance, transform.position.y - _BoxCollider.bounds.size.y - distance, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;
            //draw buttom
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y - _BoxCollider.bounds.size.y - distance, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;

        }

        if (DoesOverlap(Vector3.right) == false)
        {
           
            //draw right 
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x + _BoxCollider.bounds.size.x + distance, transform.position.y, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;

        }

        if (DoesOverlap(Vector3.left) == false)
        {
     
            //draw left
            clone = Instantiate(this.gameObject, new Vector3(transform.position.x - _BoxCollider.bounds.size.x - distance, transform.position.y, 0f), Quaternion.identity);
            clone.transform.parent = thisobject;

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            
            
            if (playerCollision == false)
            {
                EnityMan.SpawnClock();
                GeneratePlainTerrain();
            }
          
            playerCollision = true;
                  
        }

        if(collision.gameObject.tag == "big collider")
        {
            
            if (this.gameObject.name != "white background")
            {
                Destroy(gameObject);
            }

        }

        if (collision.gameObject.tag == "Medium collider")
        {
           
            playerCollision = false;
        }

        if(collision.gameObject.tag == "Terrain")
        {
            if (this.gameObject.name != "white background" && NewObject == true)
            {
                Destroy(gameObject);
            }
        }

    }

    bool DoesOverlap(Vector3 direction)
    {


        _BoxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(direction), 10f);
        _BoxCollider.enabled = true;
        //Debug.DrawRay(transform.position, transform.TransformDirection(direction) * 10f);
        if (hit == true && hit.collider.tag == "Terrain")
        {
            //hit.transform.GetComponent<SpriteRenderer>().color = Color.green;
            //Debug.Log("collision true");
            
            return true;
        }
        else
        {
            
            return false;

        }

    }

}
