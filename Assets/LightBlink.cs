using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{

    public GameObject lamp;
    bool isOn;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

            bool alreadyAdded = BeatManager.instance.allTimedActions.Contains(LampBlink);


            if (alreadyAdded == false)
            {

                BeatManager.instance.addActionToQueue(LampBlink);

            }



        
    }

    public void LampBlink()
    {
        if (isOn == false)
        {
            lamp.SetActive(true);
            isOn = true;

        }
        else if (isOn == true)
        {
            lamp.SetActive(false);
            isOn = false;

        }
    }

}
