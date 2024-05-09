using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class NewBehaviourScript : MonoBehaviour
{
    public bool idouhantei=false;//ˆÚ“®‚µ‚Ä‚¢‚é‚©‚Ç‚¤‚©
    private int hantei=0;
    
    public float Playerspeed;
    public float speeder;
    
    //[SerializeField] private CurveControlledBob headBob_ = new CurveControlledBob();
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && !CheckCollisionWithTag())
        {
            Playerspeed = speeder * 2;
        }
        else
        {
            Playerspeed = speeder;
        }
        if (Input.GetKey(KeyCode.W))
        {
            hantei = 1;
            speed.z = Playerspeed;
            idouhantei = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            hantei = 1;
            speed.z = -Playerspeed;
            idouhantei = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            hantei = 1;
            speed.x = -Playerspeed;
            idouhantei = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            hantei = 1;
            speed.x = Playerspeed;
            idouhantei = true;
        }
        else
        {
            hantei = 0;
            idouhantei = false;
        }
        if (hantei==1){
            ApplyMovement(speed);
        }
        else
        {
            transform.Translate(speed);
        }

        //Vector3 handBob = headBob_.DoHeadBob(1.0f);
        //cameraTransform_.localPosition = handBob;
         //transform.Translate(speed);
    }
    void ApplyMovement(Vector3 speed)
    {
        transform.Translate(speed);

        
    }

    
    bool CheckCollisionWithTag()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.collider.CompareTag("OtherObject"))
            {
                return true;
            }
        }
        return false;
    }
}
    
        

