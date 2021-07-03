using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameComponent : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private TMP_InputField inputField;

    private void OnEnable()
    {
        if (!string.IsNullOrEmpty(DataHolder.Instance.PlayerName)) {
            inputField.text = DataHolder.Instance.PlayerName;
        }
    }

    public void OnClickSaveButton()
    {
        DataHolder.Instance.PlayerName = inputField.text;
        menuManager.OpenMenu();
    }
}
