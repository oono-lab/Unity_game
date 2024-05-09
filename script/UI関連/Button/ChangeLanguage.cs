using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown_tmp; // TMPro版ドロップダウン
    [SerializeField] private Dropdown dropdown_lgc; // Legacy版ドロップダウン

    private const string selectedLanguageKey = "SelectedLanguage";

    void Start()
    {
        // セーブされた言語を読み込む。セーブされていなければデフォルト値を使用する。
        int savedValue = PlayerPrefs.GetInt(selectedLanguageKey, 0);
        if (dropdown_tmp != null)
            dropdown_tmp.value = savedValue;
        else if (dropdown_lgc != null)
            dropdown_lgc.value = savedValue;

        ChangeLang(); // 言語を変更する
    }

    // ドロップダウンの値が変更された時のイベントから呼び出す用
    public void ChangeSelected()
    {
        ChangeLang();
    }

    // 実際に使用言語を変更する処理
    private async Task ChangeLang()
    {
        int selectedValue = 0;
        if (dropdown_tmp != null)
            selectedValue = dropdown_tmp.value;
        else if (dropdown_lgc != null)
            selectedValue = dropdown_lgc.value;

        // このまま使う場合、case内の言語指定とドロップダウン内の項目順は合わせておくこと
        switch (selectedValue)
        {
            case 0: // 日本語
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("ja");
                break;
            case 1: // 英語
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("en");
                break;
            case 2: // 中国語(簡体字)
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("zh-Hans");
                break;
            case 3: // 中国語(繁体字)
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("zh-TW");
                break;
        }
        await LocalizationSettings.InitializationOperation.Task;

        // 選択された言語を保存する
        PlayerPrefs.SetInt(selectedLanguageKey, selectedValue);

        // 選択された言語をLanguageManagerに反映させる
        LanguageManager.SelectedLanguage = selectedValue;
    }

    // 必要に応じて、アプリケーションを終了する際にセーブする
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}

// 別のスクリプトから言語を参照するためのクラス
public static class LanguageManager
{
    // 選択された言語の値
    public static int SelectedLanguage { get; set; } = 0;
}
