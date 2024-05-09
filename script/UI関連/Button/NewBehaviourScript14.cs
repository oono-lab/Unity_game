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

    // ボタンを非表示にするメソッド
    public void HideButtons()
    {
        foreach (var pair in buttonCanvasPairs)
        {
            pair.canvasGroup.alpha = 0f; // Canvas Groupのalphaを0に設定して非表示にする
            pair.canvasGroup.blocksRaycasts = false; // レイキャストを無効にする
        }
    }

    // ボタンを表示するメソッド
    public void ShowButtons()
    {
        foreach (var pair in buttonCanvasPairs)
        {
            pair.canvasGroup.alpha = 1f; // Canvas Groupのalphaを1に設定して表示する
            pair.canvasGroup.blocksRaycasts = true; // レイキャストを有効にする
        }
    }
}
