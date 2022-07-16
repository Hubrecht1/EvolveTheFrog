using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float health = 1;
    public float healthMax = 1;
    public int time_Years = 0;

    public int cost_Years = 0;

    public float speed = 1;
    public float age = 1;

    

    [SerializeField] PlayerController _Player0;
    [SerializeField] GameObject _Player0GameO;

    [SerializeField] PlayerController _Player1;
    [SerializeField] GameObject _Player1GameO;

    [SerializeField] PlayerController _Player2;
    [SerializeField] GameObject _Player2GameO;

    [SerializeField] UI _UI;
    [SerializeField] TerrainGenerator TerrainGen;  
    [SerializeField] CameraMovement CamMov;
    [SerializeField] public EnityManager EntityMan;
    
    public GameObject CurrentPlayer;
    public GameObject CurrentPlayerClone;

    int currentStage;
    Vector3 spawnPosition;

    void Start()
    {
        currentStage = 0;
        Evolve(0);

    }
    private void Update()
    {
 
        _UI.UpdateUI();

        if(health <= 0)
        {
            StartCoroutine("Die");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            time_Years += 10;
        }



        
    }
    IEnumerator Die()
    {
        CamMov.StopUpdate = true;
        health = 10;
        Destroy(CurrentPlayerClone);
        yield return new WaitForSeconds(1f);
        Evolve(0);
    }


    public void Evolve(int stage)
    {
        if(stage == -1)
        {
            Evolve(currentStage + 1);
        }

        else if(stage == 0)
        {
            spawnPosition = new Vector3(0, 0, 0);
         
            currentStage = 0;
            CurrentPlayer = _Player0GameO;
            
            CamMov.StopUpdate = true;
            
            CurrentPlayerClone = Instantiate(_Player0GameO, spawnPosition, new Quaternion(0, 0, 0, 0));

            speed = 1f;
            health = 15f;
            healthMax = 15f;

            cost_Years = 20;

            TerrainGen.OnEvolve();
            _Player0.OnSpawn();
            EntityMan.OnPlayerSpawn();
            CamMov.Onevolution();
            CamMov.StopUpdate = false;
        }

        else if(stage == 1 && time_Years >= cost_Years)
        {
            time_Years -= cost_Years;
            currentStage = 1;
            CurrentPlayer = _Player1GameO;
            spawnPosition = CurrentPlayerClone.transform.position;
            CamMov.StopUpdate = true;
            Destroy(CurrentPlayerClone);

            CurrentPlayerClone = Instantiate(_Player1GameO, spawnPosition, new Quaternion(0, 0, 0, 0));
            speed = 1.4f;
            health = 25f;
            healthMax = 25f;

            cost_Years = 45;

            TerrainGen.OnEvolve();
            _Player1.OnSpawn();
            EntityMan.OnPlayerSpawn();
            CamMov.Onevolution();
            CamMov.StopUpdate = false;

        }

        else if (stage == 2 && time_Years >= cost_Years)
        {
            time_Years -= cost_Years;
            currentStage = 2;
            CurrentPlayer = _Player2GameO;
            spawnPosition = CurrentPlayerClone.transform.position;
            CamMov.StopUpdate = true;
            Destroy(CurrentPlayerClone);

            CurrentPlayerClone = Instantiate(_Player2GameO, spawnPosition, new Quaternion(0, 0, 0, 0));
            speed = 2f;
            health = 15f;
            healthMax = 15f;

            cost_Years = 90;

            TerrainGen.OnEvolve();
            _Player2.OnSpawn();
            EntityMan.OnPlayerSpawn();
            CamMov.Onevolution();
            CamMov.StopUpdate = false;

        }

















    }

}
