using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Listas : ScriptableObject
{
    public FichaPlayer[] personajes;

    public int contadorDePersonajes
    {
        get
        {
            return personajes.Length;
        }
    }

    public FichaPlayer ObtenerPersonaje(int index)
    {
        return personajes[index];
    }
}
