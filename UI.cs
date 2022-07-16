using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerStats;
    [SerializeField] StatsManager stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        playerStats.text = "Health: " + stats.health.ToString()  + "\nTime: " + stats.time_Years + " yr.\n" +  "Cost to evolve: " + stats.cost_Years + " yr.";

    }
}
