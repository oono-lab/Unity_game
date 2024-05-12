using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DisableScriptDuringTimeline : MonoBehaviour
{
    public List<MonoBehaviour> scriptsToDisable; // 無効にするスクリプトのリストを指定
    public List<PlayableDirector> timelines; // タイムラインを指定

    void Update()
    {
        // タイムラインが再生中かどうかを確認
        foreach (var timeline in timelines)
        {
            if (timeline != null && timeline.state == PlayState.Playing) foreach (var script in scriptsToDisable) script.enabled = false;// リスト内の全てのスクリプトを無効にする
            else foreach (var script in scriptsToDisable) script.enabled = true;// タイムラインが再生中でない場合、リスト内の全てのスクリプトを有効にする
        }
    }
}
