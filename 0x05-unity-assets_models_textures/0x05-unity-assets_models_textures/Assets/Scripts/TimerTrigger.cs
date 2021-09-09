using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        player.GetComponent<Timer>().enabled = true;
    }
}
