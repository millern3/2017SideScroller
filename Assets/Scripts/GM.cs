using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    public int lives;
    public int points;
    private Vector3 startingPosition;
    public GameObject gameOver; 
    public GameObject youWin;
    public UnityEngine.UI.Text livesValue;
    public UnityEngine.UI.Text pointsValue;
    public float deadZone = -3.2f;

    void Start ()
    {
        startingPosition = transform.position;
        livesValue.text = lives.ToString();
    }
    public void SetLives(int newValue)
    {
        lives = newValue;
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
        Debug.Log("You are out");
        lives = lives - 20;
        livesValue.text = lives.ToString();
        transform.position = startingPosition;
        GetComponent<Rigidbody2D>().velocity = new Vector2();

        if(lives == 0)
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
