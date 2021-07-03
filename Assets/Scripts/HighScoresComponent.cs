using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoresComponent : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private ScoreEntry scoreEntryPrefab;

    private List<ScoreEntry> scoreEntries = new List<ScoreEntry>();

    private void OnEnable()
    {
        if(scoreEntries.Count == 0) {
            Init();
        }

        int index = 0;
        foreach(DataHolder.HighScore entry in DataHolder.Instance.HighScores) {
            scoreEntries[index].SetValues(true, entry.Name, entry.Score);
            index++;
        }
    }

    private void Init()
    {
        for(int i = 0; i < 10; i++) {
            ScoreEntry newEntry = Instantiate(scoreEntryPrefab, content);
            newEntry.Init(i + 1);
            scoreEntries.Add(newEntry);
        }
    }
}
