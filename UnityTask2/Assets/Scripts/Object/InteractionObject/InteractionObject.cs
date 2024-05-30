using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObject : MonoBehaviour,IInteractable
{
    protected readonly int interaction = Animator.StringToHash("Interaction");

    protected string baseMessage = "[E]키를 눌러 ";
    protected string msg;

    protected Animator animator;
    protected bool toggle;

    public string message => msg;

    public abstract void Interaction(Player player);

    protected virtual void Start()
    {
        animator = GetComponentInParent<Animator>();
    }


    //public void OpenPrompt()
    //{
    //    interactionPrompt.gameObject.SetActive(true);
    //    interactionPrompt.text = message;
    //}

    //public void ClosePrompt()
    //{
    //    interactionPrompt.gameObject.SetActive(false);
    //}
}
