using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int[] dañoGolpe;
    [SerializeField] private float[] tiempoEntreAtaques;
    [SerializeField] private float[] tiempoSiguienteAtaque;

    [SerializeField] private int level;
    [SerializeField] private int experience;
    [SerializeField] private int maxExperience;
    [SerializeField] private int Healt;
    [SerializeField] private int maxHealt;
    [SerializeField] private int bonusResistence;
    [SerializeField] private int bonusDamage;


    public HealtBarScript healthbar;
    public ExperienceBarScript experiencebar;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        GameObject healthbarObject = GameObject.FindWithTag("healthbar");
        GameObject ExperiencebarObject = GameObject.FindWithTag("Experiencebar");
        healthbar = healthbarObject.GetComponent<HealtBarScript>();
        experiencebar = ExperiencebarObject.GetComponent<ExperienceBarScript>();
        Healt = maxHealt;
        healthbar.SetMaxHealth(maxHealt);
        experiencebar.SetMaxXP(maxExperience);
        
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
                animator.SetTrigger("Attack1");
                Golpe(dañoGolpe[0]);
                tiempoSiguienteAtaque[0] = tiempoEntreAtaques[0];
            }
        }

        if (tiempoSiguienteAtaque[1] <= 0)
        {
            if (Input.GetButtonDown("Attack2"))
            {
                animator.SetTrigger("Attack2");
                Golpe(dañoGolpe[1]);
                tiempoSiguienteAtaque[1] = tiempoEntreAtaques[1];
            }
        }

        if (tiempoSiguienteAtaque[2] <= 0)
        {
            if (Input.GetButtonDown("Attack3"))
            {
                animator.SetTrigger("Attack3");
                Golpe(dañoGolpe[2]);
                tiempoSiguienteAtaque[2] = tiempoEntreAtaques[2];
            }
        }

        if (Input.GetButtonDown("lost health")) 
        {
            takeDamage(50);
        }

        if (Input.GetButtonDown("Jump"))
        {
            gainXP(30);
        }
    }

    private void Golpe(int damage)
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos) 
        {
            if (colisionador.CompareTag("Enemy")) 
            {
                colisionador.transform.GetComponent<Enemy>().TomarDaño(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    public void takeDamage(int damage) 
    {
        Healt -= damage;
        healthbar.SetHealth(Healt);

        if (Healt <- 0f) 
        {
            healthbar.SetHealth(0);
            Destroy(this.gameObject);
        }
    }

    private void lvlUP()
    {
        maxHealt = (int)Math.Truncate(1.2 * maxHealt);
        maxExperience = (int)Math.Truncate(1.2 * maxExperience);
        dañoGolpe[0] = (int)Math.Truncate(1.2 * dañoGolpe[0]);
        dañoGolpe[1] = (int)Math.Truncate(1.2 * dañoGolpe[1]);
        dañoGolpe[2] = (int)Math.Truncate(1.2 * dañoGolpe[2]);
        print(dañoGolpe);
        level += 1;
        experience = 0;
        Healt = maxHealt;
    }

    public void gainXP(int xp) 
    {
        experience += xp;
        experiencebar.SetXP(experience);
        if (experience >= maxExperience)
        {  
            lvlUP();
            experiencebar.SetMaxXP(maxExperience);
            healthbar.SetMaxHealth(maxHealt);
        };
    }
}
