using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Start()
    {
        instance = this;
    }

    public void Win()
    {
        Time.timeScale = 0f;
        Debug.Log("You won!");
    }

}
