using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataOnQuit : MonoBehaviour
{
    public static SaveDataOnQuit Instance;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        DataHolder.Instance.SaveHighScoreValues();
    }
}
