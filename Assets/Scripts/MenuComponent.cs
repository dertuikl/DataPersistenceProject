using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    private void OnEnable()
    {
        nameText.text = DataHolder.Instance.PlayerName;
    }
}
