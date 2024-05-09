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
        // �Z�[�u���ꂽ�𑜓x��ǂݍ��ށB�Z�[�u����Ă��Ȃ���΃f�t�H���g�l���g�p����B
        int savedValue = PlayerPrefs.GetInt(selectedResolutionKey, 0);
        dropdown.value = savedValue;
        OnResolutionChanged(); // �h���b�v�_�E���̒l�Ɋ�Â��ĉ𑜓x��ݒ肷��
    }

    // Dropdown�̑I�����ύX���ꂽ�Ƃ��ɌĂяo�����֐�
    public void OnResolutionChanged()
    {
        if (dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 60);
        }
        else if (dropdown.value == 1)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.Windowed, 60);
        }

        // �I�����ꂽ�𑜓x��ۑ�����
        PlayerPrefs.SetInt(selectedResolutionKey, dropdown.value);
    }

    // �K�v�ɉ����āA�A�v���P�[�V�������I������ۂɃZ�[�u����
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
