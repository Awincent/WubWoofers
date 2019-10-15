using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    public float bpm;
    private float timerMax;
    private float currentTimer;
    //List<Action>() allTimedActions = new List<Action>();

    public void Start()
    {
        bpm = 120;
        timerMax = 50 / (bpm / 60);
        currentTimer = 0;
    }
    public void FixedUpdate()
    {

        currentTimer += 1;
        if(currentTimer >= timerMax)
        {

            print("Beat");



            currentTimer = 0;
            //runAllActions(/*allTimedActions*/);

        }
        
    }

    //public void runAllActions(/*allActions List<Actions>*/)
    //{

    //    for (int i = 0; i < /*allActions.lenght*/ 0; i++)
    //    {

    //        //allActions(i);

    //    }

    //}

}
