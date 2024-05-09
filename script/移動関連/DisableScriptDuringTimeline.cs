using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DisableScriptDuringTimeline : MonoBehaviour
{
    public List<MonoBehaviour> scriptsToDisable; // �����ɂ���X�N���v�g�̃��X�g���w��
    public List<PlayableDirector> timelines; // �^�C�����C�����w��

    void Update()
    {
        // �^�C�����C�����Đ������ǂ������m�F
        foreach (var timeline in timelines)
        {
            if (timeline != null && timeline.state == PlayState.Playing)
            {
                // ���X�g���̑S�ẴX�N���v�g�𖳌��ɂ���
                foreach (var script in scriptsToDisable) script.enabled = false;
            }
            else
            {
                // �^�C�����C�����Đ����łȂ��ꍇ�A���X�g���̑S�ẴX�N���v�g��L���ɂ���
                foreach (var script in scriptsToDisable) script.enabled = true;

            }
        }
    }
}
