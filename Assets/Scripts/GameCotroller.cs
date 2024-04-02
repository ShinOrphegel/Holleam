using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCotroller : MonoBehaviour
{
    public GameObject ball;
    public float spawmTime;
    private float m_spawmTime;
    private int m_score = 0;
    private bool m_isOver;
    // Start is called before the first frame update
    void Start()
    {
        m_spawmTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawmTime -= Time.deltaTime;
        if (m_spawmTime <= 0) {
            spawmBall();
            m_spawmTime = spawmTime;
        }
    }

    public void spawmBall() {
        Vector2 spawmPosition = new Vector2(Random.Range(-9, 8), 8);
        if (ball) {
            Instantiate(ball, spawmPosition, Quaternion.identity);
        }

    }

    public int getScore() {
        return m_score;
    }
    public void setScore(int value) {
        m_score = value;
    }

    public void autoIncrement() {
        m_score++;
    }

    public bool getOver() {
        return m_isOver;
    }

    public void changeOver() { 
    }
}
