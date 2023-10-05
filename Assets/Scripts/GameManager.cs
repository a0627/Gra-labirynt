using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0, 
        greenKey = 0, 
        goldKey = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time:" + timeToEnd + "s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if(endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You win! Reload?");
        }
        else
        {
            Debug.Log("You lose! Reload?");
        }
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper",freezeTime,1);
    }

    public void SubstractTime(int substractTime)
    {
        timeToEnd -= substractTime;
    }

    public void AddKey(KeyColor keyColor)
    {
        if (keyColor == KeyColor.Red)
        {
            redKey++;
        }
        else if (keyColor == KeyColor.Green)
        {
            greenKey++;
        }
        else if (keyColor == KeyColor.Gold)
        {
            goldKey++;
        }
        else
        {
            Debug.Log("Incorrect key color");
        }
    }
}

