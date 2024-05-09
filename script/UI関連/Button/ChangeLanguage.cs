using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown_tmp; // TMPro�Ńh���b�v�_�E��
    [SerializeField] private Dropdown dropdown_lgc; // Legacy�Ńh���b�v�_�E��

    private const string selectedLanguageKey = "SelectedLanguage";

    void Start()
    {
        // �Z�[�u���ꂽ�����ǂݍ��ށB�Z�[�u����Ă��Ȃ���΃f�t�H���g�l���g�p����B
        int savedValue = PlayerPrefs.GetInt(selectedLanguageKey, 0);
        if (dropdown_tmp != null)
            dropdown_tmp.value = savedValue;
        else if (dropdown_lgc != null)
            dropdown_lgc.value = savedValue;

        ChangeLang(); // �����ύX����
    }

    // �h���b�v�_�E���̒l���ύX���ꂽ���̃C�x���g����Ăяo���p
    public void ChangeSelected()
    {
        ChangeLang();
    }

    // ���ۂɎg�p�����ύX���鏈��
    private async Task ChangeLang()
    {
        int selectedValue = 0;
        if (dropdown_tmp != null)
            selectedValue = dropdown_tmp.value;
        else if (dropdown_lgc != null)
            selectedValue = dropdown_lgc.value;

        // ���̂܂܎g���ꍇ�Acase���̌���w��ƃh���b�v�_�E�����̍��ڏ��͍��킹�Ă�������
        switch (selectedValue)
        {
            case 0: // ���{��
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("ja");
                break;
            case 1: // �p��
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("en");
                break;
            case 2: // ������(�ȑ̎�)
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("zh-Hans");
                break;
            case 3: // ������(�ɑ̎�)
                LocalizationSettings.SelectedLocale = Locale.CreateLocale("zh-TW");
                break;
        }
        await LocalizationSettings.InitializationOperation.Task;

        // �I�����ꂽ�����ۑ�����
        PlayerPrefs.SetInt(selectedLanguageKey, selectedValue);

        // �I�����ꂽ�����LanguageManager�ɔ��f������
        LanguageManager.SelectedLanguage = selectedValue;
    }

    // �K�v�ɉ����āA�A�v���P�[�V�������I������ۂɃZ�[�u����
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}

// �ʂ̃X�N���v�g���猾����Q�Ƃ��邽�߂̃N���X
public static class LanguageManager
{
    // �I�����ꂽ����̒l
    public static int SelectedLanguage { get; set; } = 0;
}
