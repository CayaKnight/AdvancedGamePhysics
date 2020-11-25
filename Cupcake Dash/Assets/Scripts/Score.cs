using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private float score = 0.0f;
    public Text scoretext;
    public Text deathText;
    private int difficultylevel = 1;
    private int maxlevel = 10;
    private int scoretochangelvl = 10;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead)
        {
            deathText.text = ("You have died!");
            return;
        }
        if (score >= scoretochangelvl)
        {
            levelup();
        }

        score += Time.deltaTime;
        scoretext.text = ((int)score).ToString();
    }

    void levelup()
    {
        if (difficultylevel == maxlevel)
        {
            return;
        }
        scoretochangelvl *= 2;
        difficultylevel++;
        Debug.Log(difficultylevel);
        GetComponent<PlayerMovement>().setspeed(difficultylevel);
    }

    public void OnDeath()
    {
        isDead = true;
    }
}
