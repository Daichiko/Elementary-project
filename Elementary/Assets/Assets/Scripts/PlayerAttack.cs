using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float[] tiempoEntreAtaques;
    [SerializeField] private float[] tiempoSiguienteAtaque;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        for (int i = 0; i < tiempoSiguienteAtaque.Length; i++)
        {
            float tiempo = tiempoSiguienteAtaque[i];

            if (tiempo > 0)
            {
                float nuevoTiempo = tiempo - Time.deltaTime;
                tiempoSiguienteAtaque[i] = nuevoTiempo;
            }
        }

        if (tiempoSiguienteAtaque[0] <= 0)
        {
            if (Input.GetButtonDown("Attack1"))
            {
                print("entre1");
                animator.SetTrigger("Attack1");
                Golpe();
                tiempoSiguienteAtaque[0] = tiempoEntreAtaques[0];
            }
        }

        if (tiempoSiguienteAtaque[1] <= 0)
        {
            if (Input.GetButtonDown("Attack2"))
            {
                print("entre2");
                animator.SetTrigger("Attack2");
                Golpe();
                tiempoSiguienteAtaque[1] = tiempoEntreAtaques[1];
            }
        }

        if (tiempoSiguienteAtaque[2] <= 0)
        {
            if (Input.GetButtonDown("Attack3"))
            {
                print("entre3");
                animator.SetTrigger("Attack3");
                Golpe();
                tiempoSiguienteAtaque[2] = tiempoEntreAtaques[2];
            }
        }      
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos) 
        {
            if (colisionador.CompareTag("Enemy")) 
            {
                colisionador.transform.GetComponent<Enemy>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
