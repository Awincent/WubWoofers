using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSongLevels : MonoBehaviour
{
    public GameObject[] audioThings;
    bool volUp;
    bool volDown;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(volUp == true){
            audioSource.volume = Mathf.Lerp(audioSource.volume, 1f, Time.deltaTime);
        }
    }

    public void OnAudioLevelChange(int i){
        AudioSource audioSource = new AudioSource();
        audioSource = audioThings[i].GetComponent<AudioSource>();

        volUp = true;
    }

}
