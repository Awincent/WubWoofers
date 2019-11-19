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
    Queue<Action> allTimedActions = new Queue<Action>();

    public static BeatManager instance;

    public void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = song;
        audioSource.Play();

        if (instance == null)
        {
            instance = this;
        }

        
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

}
