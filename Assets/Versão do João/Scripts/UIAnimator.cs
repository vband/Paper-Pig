using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour {

    private Animator anim;
    private string[] textOptions = new string[3];
    private int option; 


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeText(string sense)
    {
        switch (sense)
        {
            case "Direita":
                option++;
                break;
            case "Esquerda":
                option--;
                break;
        }
        //options[option];
    }

    public void Animate()
    {
        anim.SetTrigger("HideShow");
    }
}
