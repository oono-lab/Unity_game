using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class NewBehaviourScript10 : MonoBehaviour
{
    public GameObject[] targetObjects; // �Ώۂ̃I�u�W�F�N�g�̔z��
    public TextMeshProUGUI displayText;
    private string fullText="�������炳���ɂ͋������͂Ȃ��������B";
    private string fullText_en = "There does not seem to be any buckwheat noodle shops beyond this point.";
    private string fullTexts_show;
    private string currentText = "";
    private int currentIndex = 0;
    private Move sound_hantei;
    private AudioSource text_Audio;
    private float textDisplaySpeed = 0.05f; // �e�L�X�g��\�����鑬�x�i�b�j
    private float timer = 0f; // ���Ԍv���p�̃^�C�}�[
    void Start()
    {
        GameObject targetObject1 = GameObject.Find("Canvas");
        text_Audio = targetObject1.GetComponent<AudioSource>();
        GameObject targetObject = GameObject.Find("Main Camera");
        sound_hantei = targetObject.GetComponent<Move>();
        displayText.enabled = false;
        displayText.text = currentText;
        
    }
    void Update()
    {
        OnLanguageChanged();
        Vector3 tmp = targetObjects[0].transform.position;
        if (tmp.z>=30 || tmp.z<=-20)
        {
            sound_hantei.StopAudio();
            script_hantei1(false);
            displayText.enabled = true;
            // �����̃I�u�W�F�N�g�ɃA�^�b�`���ꂽ����̃X�N���v�g�𖳌��ɂ���
         
        }
        if(displayText.enabled == true)
        {
            if (currentIndex < fullTexts_show.Length)
            {
                timer += Time.deltaTime; // �^�C�}�[���X�V

                // �w�肵�����x�ȏ�̎��Ԃ��o�߂����玟�̕�����\������
                if (timer >= textDisplaySpeed)
                {
                    currentText += fullTexts_show[currentIndex]; // ���̕�����ǉ�
                    displayText.text = currentText; // �e�L�X�g���X�V
                    currentIndex++; // �C���f�b�N�X�𑝂₷
                    timer = 0f; // �^�C�}�[�����Z�b�g
                }

            }
            if (Input.GetMouseButtonDown(0))
            {

                
                if(tmp.z >= 30)
                {
                    targetObjects[0].transform.position = new Vector3(tmp.x, tmp.y, tmp.z - 1);
                }
                else
                {
                    targetObjects[0].transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                }
                text_Audio.Play();
                text_root1();
                displayText.enabled = false;
                script_hantei1(true);
                

                
                

            }
        }
    }
    void script_hantei1(bool hantei)
    {
        foreach (GameObject obj in targetObjects)
        {
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = hantei;
            }
        }
    }
    void text_root1()
    {
        fullTexts_show = "";
        currentText = "";
        currentIndex = 0;
    }
    void OnLanguageChanged()
    {
        if (LanguageManager.SelectedLanguage == 0) OnLanguageChanged_jp();
        else OnLanguageChanged_en();
    }
    void OnLanguageChanged_jp()
    {
        fullTexts_show = fullText;
        textDisplaySpeed = 0.05f;
    }
    void OnLanguageChanged_en()
    {
        fullTexts_show = fullText_en;
        textDisplaySpeed = 0.03f;
    }


}
