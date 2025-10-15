using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : Stuff
{

    public Switch() { 
        Name = "Switch";
    }
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    [SerializeField]
    bool isOn = false;
    Animator animator;
    public Identity InteracTo;

    IInteractable Iinteract
    {
        get
        {
            return Iinteract as IInteractable;
        }
    }
    public void Interact(Player player)
    {
        isOn = !isOn;
        if (isOn)
        {
            Debug.Log("Switch on");
            Iinteract?.Interact(player);
        }
        else
        {
            Debug.Log("Switch off");
            Iinteract?.Interact(player);
        }
    }
}

