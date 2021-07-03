using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public class HighScore : IComparable
    {
        public string Name;
        public int Score;

        public HighScore(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(object obj)
        {
            HighScore other = obj as HighScore;
            if(other == null ) {
                return 1;
            }
            return this.Score.CompareTo(other.Score);
        }
    }

    private static DataHolder instance;
    public static DataHolder Instance => instance ?? (instance = new DataHolder());

    public string PlayerName {
        get => PlayerPrefs.GetString("player_name", string.Empty);
        set => PlayerPrefs.SetString("player_name", value);
    }

    private List<HighScore> highScores = new List<HighScore>();

    public List<HighScore> HighScores {
        get {
            if(highScores.Count == 0) {
                LoadHighScoreValues();
            }
            highScores.Sort();
            highScores.Reverse();
            return highScores;
        }
    }

    public void SaveHighScore(int score)
    {
        HighScore newHighScore = new HighScore(PlayerName, score);
        highScores.Insert(0, newHighScore);
    }

    private void LoadHighScoreValues()
    {
        for(int i = 0; i < 10; i++) {
            if(PlayerPrefs.HasKey(i + "_high_score_name")) {
                string name = PlayerPrefs.GetString(highScores.Count + "_high_score_name");
                int score = PlayerPrefs.GetInt(highScores.Count + "_high_score_score");
                highScores.Add(new HighScore(name, score));
            } else {
                break;
            }
        }
    }

    public void SaveHighScoreValues()
    {
        var toSave = HighScores;
        for(int i = 0; i < 10; i++) {
            if(i >= toSave.Count) {
                break;
            }

            PlayerPrefs.SetString(i + "_high_score_name", toSave[i].Name);
            PlayerPrefs.SetInt(i + "_high_score_score", toSave[i].Score);
        }
    }
}
