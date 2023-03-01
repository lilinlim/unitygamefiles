using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable { 
 //MonoBehaviour {

    //public SignalSender contextOn;
    //public SignalSender contextOff;
    //public SignalSender context;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    //public bool playerInRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) //check caps
        {
            //contextOff.Raise();
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
