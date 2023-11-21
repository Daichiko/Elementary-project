using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarDaño(float daño) 
    {
        vida -= daño;

        if (vida <= 0) 
        {
            Muerte();
        }
    }

    public void Muerte() 
    {
        //animator.SetTrigger("Muerte");
        print("muerte");
        Destroy(this.gameObject);
    }
}
