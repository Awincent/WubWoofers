using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour
{

public UnityEvent whatToDo;
public float buttonBounce;
private AudioSource audioSource;
GameObject button;
Rigidbody rb;
private void Start() 
{
    button = this.gameObject;
    rb = button.GetComponent<Rigidbody>();
    audioSource = button.GetComponent<AudioSource>();
}
private void OnMouseUp() 
{
    rb.AddForce(transform.up * buttonBounce);
    audioSource.Play();
    whatToDo.Invoke();
}

}