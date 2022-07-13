using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float health = 1;
    public float speed = 1;
    public float age = 1;

    [SerializeField] PlayerController _Player0;
    [SerializeField] GameObject _Player0GameO;
    [SerializeField] PlayerController _Player1;
    [SerializeField] GameObject _Player1GameO;

    [SerializeField] TerrainGenerator TerrainGen;  
    [SerializeField] CameraMovement CamMov;
    [SerializeField] public EnityManager EntityMan;
    
    public GameObject CurrentPlayer;
    public GameObject CurrentPlayerClone;
    int currentStage;


    void Start()
    {
        currentStage = 0;
        Evolve(0);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            Evolve(1);
        }
    }

    public void Evolve(int stage)
    {
        if(stage == -1)
        {
            Evolve(currentStage + 1);
        }

        else if(stage == 0)
        {
            currentStage = 0;
            CurrentPlayer = _Player0GameO;
            CurrentPlayerClone = Instantiate(_Player0GameO, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

            TerrainGen.OnEvolve();
            _Player0.OnSpawn();
            EntityMan.OnPlayerSpawn();
            CamMov.Onevolution();
            
        }

        else if(stage == 1)
        {
            currentStage = 1;
            CurrentPlayer = _Player1GameO;
            Vector3 spawnPosition = CurrentPlayerClone.transform.position;
            CamMov.StopUpdate = true;
            Destroy(CurrentPlayerClone);

            CurrentPlayerClone = Instantiate(_Player1GameO, spawnPosition, new Quaternion(0, 0, 0, 0));
            speed = 1.4f;

            TerrainGen.OnEvolve();
            _Player1.OnSpawn();
            EntityMan.OnPlayerSpawn();
            CamMov.Onevolution();
            CamMov.StopUpdate = false;

        }


    }

}
