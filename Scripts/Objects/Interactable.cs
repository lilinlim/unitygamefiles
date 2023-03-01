using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public SignalSender context;
    public bool playerInRange;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) //check caps
        {
            //contextOn.Raise();
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) //check caps
        {
            //contextOff.Raise();
            context.Raise();
            playerInRange = false;
            //dialogBox.SetActive(false);
        }
    }
}
