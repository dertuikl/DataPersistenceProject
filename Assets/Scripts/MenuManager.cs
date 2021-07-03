using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuField;
    [SerializeField] private GameObject highScoresField;
    [SerializeField] private GameObject nameChangeField;

    private GameObject activeField = null;

    private void Start()
    {
        if (string.IsNullOrEmpty(DataHolder.Instance.PlayerName)) {
            OpenNameChange();
        } else {
            OpenMenu();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenMenu()
    {
        ChangeField(menuField);
    }

    public void OpenHighScores()
    {
        ChangeField(highScoresField);
    }

    public void OpenNameChange()
    {
        ChangeField(nameChangeField);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void ChangeField(GameObject newField)
    {
        if(activeField != null) {
            activeField.SetActive(false);
        }
        activeField = newField;
        activeField.SetActive(true);
    }
}
