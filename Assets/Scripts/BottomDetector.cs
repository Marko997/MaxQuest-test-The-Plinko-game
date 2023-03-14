using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomDetector : MonoBehaviour
{
    public int scoreModifier;
    public TMP_Text scoreText;
    static int score;

    void Start()
    {
        score = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        score += scoreModifier;
        scoreText.text = $"Score: {score}";
    }
}
