using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    public delegate void Action();

    public float bpm;
    private float timerMax;
    private float currentTimer;
    public Material lit;
    public Material notLit;
    Queue<Action> allTimedActions = new Queue<Action>();

    public void Start()
    {

        GetComponent<Renderer>().material = notLit;
        timerMax = 1f /(bpm / 60f);
        currentTimer = 0;
    }
    public void Update()
    {


        currentTimer += Time.deltaTime;

        if(currentTimer >= timerMax)
        {
            currentTimer = currentTimer % timerMax;
            runAllActions(allTimedActions);
            StartCoroutine("lightTheFuses");
        }
        
    }

    

    public void addActionToQueue(Action actionToAdd)
    {

        allTimedActions.Enqueue(actionToAdd);

    }

    private void runAllActions(Queue<BeatManager.Action> allActions)
    {

        while (allTimedActions.Count > 0f)
        {
            Action a = allTimedActions.Dequeue();
            a();
        }

    }


    public IEnumerator lightTheFuses()
    {

        GetComponent<Renderer>().material = lit;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = notLit;
        yield break;
    }
}
