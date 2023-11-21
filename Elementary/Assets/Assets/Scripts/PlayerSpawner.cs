using Cinemachine;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Listas lista_Personajes;

    private int contadorDePersonajes;

    private Transform player;
    private GameObject playerObj;

    [SerializeField] private CinemachineVirtualCamera cameraObj;

    void Start()
    {
        if (!PlayerPrefs.HasKey("contadorDePersonajes"))
        {
            contadorDePersonajes = 0;
        }
        else
        {
            Cargar();
        }

        InvocarPersonaje(contadorDePersonajes);

        Follow();

        Destroy(this.gameObject);
    }

    private void InvocarPersonaje(int contadorDePersonajes)
    {
        FichaPlayer personaje = lista_Personajes.ObtenerPersonaje(contadorDePersonajes);
        Instantiate(personaje.objeto_Jugador, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    private void Cargar()
    {
        contadorDePersonajes = PlayerPrefs.GetInt("contadorDePersonajes");
    }

    private void Follow()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
        cameraObj.Follow = player;
    }
}
