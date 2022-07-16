using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] AudioSource buttonClick;

    public void PlaybuttonClick()
    {
        buttonClick.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
