using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine.Playables;

public class DisplayTextOnKeyPress : MonoBehaviour
{
    
    public PlayableDirector timelineDirector;
    public GameObject game_setumei_UI;//�e�L�X�g��ǂݏI���ĕ\������ۂ�UI�B���XUI���\���ɐݒ肷��K�v������
    public GameObject[] targetObjects;//�e�L�X�g�\�����ɕt�^����Ă���X�N���v�g��S�Ė����ɂ���
    public KeyCode displayKey = KeyCode.Space; // �\���L�[�Ƃ��Đݒ肷��L�[�R�[�h
    public TextMeshProUGUI displayText; // �\������e�L�X�gUI
    public Outline outline; // �A�E�g���C���R���|�[�l���g
    public string[] fullTexts; // �\��������e�L�X�g
    public int hantei = 0;
    private string currentText = ""; // ���ݕ\������Ă���e�L�X�g
    private int currentIndex = 0;
    private int count = 0;// ���ݕ\�����Ă��镶���̃C���f�b�N�X
    private float textDisplaySpeed = 0.05f; // �e�L�X�g��\�����鑬�x�i�b�j
    private int numberOfElements;
    private float timer = 0f; // ���Ԍv���p�̃^�C�}�[ 
    public float targetTime = 0.0f;
    void Start()
    {
        numberOfElements = fullTexts.Length;
        displayText.enabled = false;
        displayText.text = currentText;
    }
    void Update()
    {
        // �A�E�g���C�����\������Ă��āA����̃L�[�������ꂽ��
            
            if ((outline.enabled == true && Input.GetKey(displayKey))||(hantei!=0))
            {
            
            
                script_hantei(false);
            
            

            
            if (hantei == 2)
            {if (timelineDirector.time >= targetTime)
                {
                    displayText.enabled = true;
                    timelineDirector.Pause();
                }
                  
            }else
            {
                displayText.enabled = true;
            }
                
            }
            if (displayText.enabled == true)
            {
            if (currentIndex < fullTexts[count].Length)
            {   
                timer += Time.deltaTime; // �^�C�}�[���X�V

                // �w�肵�����x�ȏ�̎��Ԃ��o�߂����玟�̕�����\������
                if (timer >= textDisplaySpeed)
                {
                    currentText += fullTexts[count][currentIndex]; // ���̕�����ǉ�
                    displayText.text = currentText; // �e�L�X�g���X�V
                    currentIndex++; // �C���f�b�N�X�𑝂₷
                    timer = 0f; // �^�C�}�[�����Z�b�g
                }
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                
                if (numberOfElements-1 <= count)
                {
                    
                    
                    count = 0;
                    text_root();
                    if (game_setumei_UI ==�@null)
                    {
                        script_hantei(true);
                    }
                    else
                    {
                       
                        game_setumei_UI.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                    }
                    
                    displayText.enabled = false;
                    if (hantei == 2)
                    {
                        timelineDirector.Play();
                    }
                    hantei = 0;

                }
                else
                {
                    count++;
                    text_root();
                }
                
            }
        }
        

            
        }
    void text_root()
    {
        currentText = "";
        currentIndex = 0;
    }
    public void script_hantei(bool hantei)
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
    }

