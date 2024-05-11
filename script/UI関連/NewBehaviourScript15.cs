using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript15 : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private const string selectedResolutionKey = "SelectedResolution";

    void Start()
    {
        // セーブされた解像度を読み込む。セーブされていなければデフォルト値を使用する。
        int savedValue = PlayerPrefs.GetInt(selectedResolutionKey, 0);
        dropdown.value = savedValue;
        OnResolutionChanged(); // ドロップダウンの値に基づいて解像度を設定する
    }

    // Dropdownの選択が変更されたときに呼び出される関数
    public void OnResolutionChanged()
    {
        if (dropdown.value == 0) Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 60);
        else Screen.SetResolution(1920, 1080, FullScreenMode.Windowed, 60);
        // 選択された解像度を保存する
        PlayerPrefs.SetInt(selectedResolutionKey, dropdown.value);
    }

    // 必要に応じて、アプリケーションを終了する際にセーブする
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
