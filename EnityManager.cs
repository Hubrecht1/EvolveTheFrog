using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnityManager : MonoBehaviour
{
    [SerializeField] GraspAbleScript _GraspAble;
    [SerializeField] StatsManager StatsMan;
    GameObject _Player;
    [SerializeField] GameObject _Clock;
    [SerializeField] GameObject _Turret;
    [SerializeField] TurretGunController _TurrentCon;
    [SerializeField] GameObject _TurretGun;

    [SerializeField] GameObject EntitiesFile;

    public int clockCount = 0;
    public int clockCountMax = 10;

    [SerializeField] public int turretCount = 0;
    [SerializeField] public int turretCountMax = 4;

    



    public void OnPlayerSpawn()
    {
        
        _Player = StatsMan.CurrentPlayerClone;

    }
    
    public void SpawnClock()
    {
        int minAmount = 1;
        int maxAmount = 4;
        int cycles = Random.Range(minAmount, maxAmount);

        for (int i = 0; i < cycles ;i++)
        {
            if (clockCount <= clockCountMax)
            {
                clockCount++;

                float yoffset = Random.Range(-8f, 8f);
                float xoffset = Random.Range(-8f, 8f);

                _GraspAble.SpriteR.sortingLayerName = "foreground";

                GameObject __Clock = Instantiate(_Clock, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));
                __Clock.transform.parent = EntitiesFile.transform;

            }
        }


    }

    public void SpawnTurret()
    {
       
        float yoffset = Random.Range(5f, 15f);
        float xoffset = Random.Range(-10f, 10f);

        Instantiate(_Turret, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(_TurretGun, _Player.transform.position + new Vector3 (xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));

        yoffset = Random.Range(-5f, -10f);
        xoffset = Random.Range(-10f, 10f);

        Instantiate(_Turret, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(_TurretGun, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));

        yoffset = Random.Range(-10f, 10f);
        xoffset = Random.Range(5f, 15f);

        Instantiate(_Turret, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(_TurretGun, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));

        yoffset = Random.Range(-10f, 10f);
        xoffset = Random.Range(-5f, -15f);

        Instantiate(_Turret, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(_TurretGun, _Player.transform.position + new Vector3(xoffset, yoffset, 0), new Quaternion(0, 0, 0, 0));

        turretCount += 4;
    }

    void Awake()
    {
        clockCount = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            SpawnTurret();
        }
    }
}
