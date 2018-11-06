using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    private PigPicker picker;

    [SerializeField] private List<GameObject> skins;

    public List<GameObject> Skins
    {
        get
        {
            return skins;
        }
    }

    private void Start()
    {
        picker = FindObjectOfType<PigPicker>();
        picker.SetUp(this);
        picker.PigChoice(PlayerPrefs.GetInt("Skin"));
    }
}
