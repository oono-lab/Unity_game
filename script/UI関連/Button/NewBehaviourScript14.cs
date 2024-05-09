using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript14 : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class ButtonCanvasGroupPair
    {
        public Button button;
        public CanvasGroup canvasGroup;
    }

    public List<ButtonCanvasGroupPair> buttonCanvasPairs;

    // �{�^�����\���ɂ��郁�\�b�h
    public void HideButtons()
    {
        foreach (var pair in buttonCanvasPairs)
        {
            pair.canvasGroup.alpha = 0f; // Canvas Group��alpha��0�ɐݒ肵�Ĕ�\���ɂ���
            pair.canvasGroup.blocksRaycasts = false; // ���C�L���X�g�𖳌��ɂ���
        }
    }

    // �{�^����\�����郁�\�b�h
    public void ShowButtons()
    {
        foreach (var pair in buttonCanvasPairs)
        {
            pair.canvasGroup.alpha = 1f; // Canvas Group��alpha��1�ɐݒ肵�ĕ\������
            pair.canvasGroup.blocksRaycasts = true; // ���C�L���X�g��L���ɂ���
        }
    }
}
