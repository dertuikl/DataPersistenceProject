using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreEntry : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Init(int number)
    {
        numberText.text = number.ToString();
        content.SetActive(false);
    }

    public void SetValues(bool enabled, string name = "", int score = 0)
    {
        content.SetActive(enabled);
        nameText.text = name;
        scoreText.text = score.ToString();
    }
}
