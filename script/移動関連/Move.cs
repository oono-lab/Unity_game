using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Move : MonoBehaviour

{
    public AudioClip[] audioClip;
    private AudioSource audioSource;
    private Camera mainCamera_;
    private Transform cameraTransform_;
    private NewBehaviourScript iscameraShake;
    private int run_or_walk = 0;
    [SerializeField] private CurveControlledBob headBob_ = new CurveControlledBob();

    // Start is called before the first frame update
    void Start()
    {
        //cameraShake = GetComponentInChildren<NewBehaviourScript>();
        cameraTransform_ = this.GetComponent<Transform>();
        mainCamera_ = this.GetComponent<Camera>();
        headBob_.Setup(mainCamera_, 1.0f);
        iscameraShake = this.GetComponent<NewBehaviourScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iscameraShake.idouhantei == true) {
            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
            {
                
                if (run_or_walk == 1)
                {
                    StopAudio();
                }
                run_or_walk = 0;
                PlayAudio(1);
                Vector3 handBob = headBob_.DoHeadBob(4.0f);
                cameraTransform_.localPosition = handBob;

            }
            else
            {
                if (run_or_walk == 0)
                {
                    StopAudio();
                }
                run_or_walk = 1;
                PlayAudio(0);
                Vector3 handBob = headBob_.DoHeadBob(2.0f);
                cameraTransform_.localPosition = handBob;

            }
             
        }
        else
        {
            StopAudio();
            Vector3 handBob = headBob_.DoHeadBob(0.0f);
            cameraTransform_.localPosition = handBob;
        }
        
        
       
            
        
        
    }
    void PlayAudio(int num)
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClip[num];
            audioSource.Play();
        }
    }
    public void StopAudio()
    {
        if (audioSource.isPlaying) audioSource.Stop(); // 再生中のオーディオを停止
    }
}
