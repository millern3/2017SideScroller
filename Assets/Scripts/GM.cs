using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    private int _Lives = 3;
    public int points;
    public GameObject gameOverSign; 
    public GameObject youWin;
    public Text livesValue;
    public Text pointsValue;

    
    public void SetLives(int newValue)
    {
        _Lives = newValue;
        Debug.Log("Lives now equals:" + _Lives);
        livesValue.text = _Lives.ToString();

        if(_Lives == 0)
        {
            gameOverSign.SetActive(true);
        }
    }
    public int GetLives()
    {
        return _Lives;
    }
    public void CoinCollected (int worth)
    {
        points += worth;
        pointsValue.text = points.ToString();
    }
}
