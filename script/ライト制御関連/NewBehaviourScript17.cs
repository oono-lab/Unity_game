using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript17 : MonoBehaviour
{
    // Start is called before the first frame update
    public Light light_this;
    private float timer = 0f; // ŽžŠÔŒv‘ª—p‚Ìƒ^ƒCƒ}[
    private float light_hikaku;
    // Start is called before the first frame update
    void Start()
    {
         light_hikaku= light_this.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=0.1&& light_hikaku== light_this.intensity) light_this.intensity = light_this.intensity - 1;
        if(timer >= 0.2)
        {
            //Debug.Log(timer);
            light_this.intensity = light_this.intensity + 1;
            timer = 0f;
        }
    }
}
