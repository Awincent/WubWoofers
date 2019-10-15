using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    public GameObject player;
    public GameObject whereShootFrom;


    private void OnMouseUp() 
    {
        player.GetComponent<Player>().chosenGun = this.gameObject;
        player.GetComponent<Player>().whereShoot = whereShootFrom;
    }
}
