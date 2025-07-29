using UnityEngine;

public class Door : Interactable
{
    public GameObject door;
    private bool doorOpen;

    protected override void Interact()
    {
        doorOpen = !doorOpen; //toggle function
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
