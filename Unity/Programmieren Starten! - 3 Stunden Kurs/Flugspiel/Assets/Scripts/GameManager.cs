using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
}
