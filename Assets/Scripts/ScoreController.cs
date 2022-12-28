using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    
    public TextMeshProUGUI Text;
    public TextMeshProUGUI DeathText;
    public GameObject player;
    public int score;
    void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        setscore(Text);
    }
    public void setscore(TextMeshProUGUI txt)
    {
        score = Mathf.RoundToInt(player.transform.position.z);
        txt.text = score.ToString();
    }
}
