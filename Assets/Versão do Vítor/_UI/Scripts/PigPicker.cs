using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

//[System.Serializable]
//public class PickerEvents : UnityEvent { }

public class PigPicker : MonoBehaviour {

    public GameObject porco;
    public List<GameObject> skins;
    //[SerializeField] int quantidadeDeSkins;
    private int porcoEscolhido = 0;
    private int porcoAnterior = 0;

    public int PorcoEscolhido
    {
        get
        {
            return porcoEscolhido;
        }

        set
        {
            porcoEscolhido = value;
        }
    }

    //public PickerEvents choiceEvent;
    void Start()
    {
        PigPicker other = FindObjectOfType<PigPicker>();
        if (other != this) Destroy(other.gameObject);

        porco = FindObjectOfType<PlayerSkinController>().gameObject;
        skins = porco.GetComponent<PlayerSkinController>().Skins;

        //porcoEscolhido = 0;
        //porcoAnterior = 0;
        //skins = new GameObject[quantidadeDeSkins];
        DontDestroyOnLoad(this.gameObject);
    }

    public void PigChoice(int op)
    {
        porcoAnterior = porcoEscolhido;
        porcoEscolhido = op;
        PlayerPrefs.SetInt("Skin", op);
        //Debug.Log("Porco escolhido: " + porcoEscolhido);
        ChangePig();
    }

    private void ChangePig()
    {
        //print("anterior: " + porcoAnterior + ", escolhido: " + PlayerPrefs.GetInt("Skin"));
        skins[porcoAnterior].SetActive(false);
        skins[PlayerPrefs.GetInt("Skin")].SetActive(true);
    }

    public void SetUp(PlayerSkinController skinController)
    {
        porco = skinController.gameObject;
        skins = skinController.Skins;
    }
}
