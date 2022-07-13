using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject _Player;
    [SerializeField] StatsManager StatsMan;
    public bool StopUpdate;

    public void Onevolution()
    {
        _Player = StatsMan.CurrentPlayerClone;

    }

    private void LateUpdate()
    {
        if(StopUpdate == false)
        { 
            transform.position = new Vector3(_Player.transform.position.x, _Player.transform.position.y, -1f);

        }

    }
}
