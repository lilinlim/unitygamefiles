using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable {

    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                //open the chest
                OpenChest();
            }else
            {
                //chest already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        //dialog window on
        dialogBox.SetActive(true);
        //dialog text = contents text
        dialogText.text = contents.itemDescription;
        //add contents to inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //raise the signal to the player to animate
        raiseItem.Raise();
        //raise the context clue
        context.Raise();
        //set the chest to opened
        isOpen = true;
        anim.SetBool("opened", true);
    }

    public void ChestAlreadyOpen()
    {
            //dialog off
            dialogBox.SetActive(false);
            //raise the signal to the player to stop anim
            raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen) //check caps
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen) //check caps
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
