using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder
{
    private static DataHolder instance;
    public static DataHolder Instance => instance ?? (instance = new DataHolder());

    public string PlayerName {
        get => PlayerPrefs.GetString("player_name", string.Empty);
        set => PlayerPrefs.SetString("player_name", value);
    }
}
