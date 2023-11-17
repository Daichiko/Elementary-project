using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    public Image[] selectionBoxes;

    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var img in this.selectionBoxes)
        { 
            img.gameObject.SetActive(false);
        }

        this.Select(0);
    }


    public void Select(int index)
    {
        foreach (var img in this.selectionBoxes)
        {
            img.gameObject.SetActive(false);
        }

        this.selectionBoxes[index].gameObject.SetActive(true);
        PlayerPrefs.SetInt("contadorDePersonajes", index);
    }

    public void CambioEscena(int idEscena)
    {
        SceneManager.LoadScene(idEscena);
    }
}
