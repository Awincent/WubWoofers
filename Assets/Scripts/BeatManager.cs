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
    public Material lit;
    public Material notLit;
    //List<Action>() allTimedActions = new List<Action>();

    public void Start()
    {
        GetComponent<Renderer>().material = notLit;
        bpm = 120;
        timerMax = 50 / (bpm / 60);
        currentTimer = 0;
    }
    public void FixedUpdate()
    {

        GetComponent<Renderer>().material = notLit;

        currentTimer += 1;
        if(currentTimer >= timerMax)
        {
            GetComponent<Renderer>().material = lit;
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
