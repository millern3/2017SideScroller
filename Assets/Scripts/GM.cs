using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    private int _Lives = 3;
    public int points;
    public GameObject gameOver; 
    public GameObject youWin;
    public Text livesValue;
    public Text pointsValue;
    public float deadZone = -3.2f;

    
    public void SetLives(int newValue)
    {
        _Lives = newValue;
        Debug.Log("Lives now equals:" + _Lives);
        livesValue.text = _Lives.ToString();
    }
    public int GetLives()
    {
        return _Lives;
    }
    void Update ()
    {
        if(transform.position.y < deadZone)
        {
            GetOut();
        }
    }
    void GetOut ()
    {
        if(_Lives == 0)
        {
            DoGameOver();
        }
    }
    void DoGameOver()
    {
        gameOver.SetActive(true);
    }
    public void CoinCollected (int worth)
    {
        points += worth;
        pointsValue.text = points.ToString();

        var coinsLeft = FindObjectsOfType<Coin>().Length;
        if(coinsLeft == 0)
        {
            youWin.SetActive(true);
        } 
    }
}
