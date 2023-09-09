using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    public static int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.SetText(score.ToString());
    }
}
