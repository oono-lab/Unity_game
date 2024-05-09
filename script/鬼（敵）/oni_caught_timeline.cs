using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class oni_caught_timeline : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    public GameObject oni_timeline_stand;
    
    // Start is called before the first frame update
    void Start()
    {
      
        

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // �Փ˂����I�u�W�F�N�g������̃^�O�������Ă���ꍇ�ɏ������s��
        if (other.CompareTag("humanObject"))
        {
            Cursor.lockState = CursorLockMode.None;
            oni_timeline_stand.SetActive(true);
            timelineToPlay.Play();
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

        }
    }
}
