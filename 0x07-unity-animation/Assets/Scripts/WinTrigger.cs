using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Text Timertext;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        Timertext.fontSize = 80;
        Timertext.color = Color.green;
    }
}
