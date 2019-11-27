using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    public delegate void Action();

    public float bpm;
    public AudioClip song;
    private AudioSource audioSource;
    private float timerMax;
    private float currentTimer;
    private float halfbeatTimerMax;
    private float currentHalfbeatTimer;
    public Queue<Action> allTimedActions = new Queue<Action>();
    public Queue<Action> allHalfbeatActions = new Queue<Action>();
    private List<int> beatTimers;
    private List<Action> beatTimerActions;



    public static BeatManager instance;

    public void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = song;

        addActionToQueue(audioSource.Play);


        if (instance == null)
        {
            instance = this;
        }



        timerMax = 1f / (bpm / 60f);
        currentTimer = 0;
        halfbeatTimerMax = 1f / (bpm / 30f);
        currentHalfbeatTimer = 0;

    }
    public void Update()
    {


        currentTimer += Time.deltaTime;
        currentHalfbeatTimer += Time.deltaTime;


        if (currentTimer >= timerMax)
        {
            currentTimer = currentTimer % timerMax;
            runAllActions(allTimedActions);
        }
        if (currentHalfbeatTimer >= halfbeatTimerMax)
        {

            currentHalfbeatTimer = currentHalfbeatTimer % halfbeatTimerMax;
            runHalfbeatActions(allHalfbeatActions);

        }


    }


    public void addActionToHalfbeatQueue(Action actionToAdd)
    {

        allHalfbeatActions.Enqueue(actionToAdd);

    }
    private void runHalfbeatActions(Queue<BeatManager.Action> allActions)
    {

        while (allHalfbeatActions.Count > 0f)
        {

            Action a = allHalfbeatActions.Dequeue();
            a();

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

        for (int i = 0; i < beatTimers.Count; i++)
        {
            beatTimers[i]--;

            if (beatTimers[i] <= 0)
            {
                beatTimerActions[i]();
                beatTimers.RemoveAt(i);
                beatTimerActions.RemoveAt(i);

            }
        }

    }

    public void beatCounter(int howMany, Action what)
    {

        beatTimers.Add(howMany);
        beatTimerActions.Add(what);


    }


}
