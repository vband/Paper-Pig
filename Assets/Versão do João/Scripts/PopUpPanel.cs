using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : MonoBehaviour {

    bool clickControl1 = true;
    bool clickControl2 = false;
    public GameObject panel;

	public void _ShowAndHide()
    {
        panel.SetActive(clickControl1);
        bool temp = clickControl1;
        clickControl1 = clickControl2;
        clickControl2 = temp;
    }
}
