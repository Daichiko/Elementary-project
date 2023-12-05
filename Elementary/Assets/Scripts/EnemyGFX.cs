using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyGFX : MonoBehaviour
{
    // Start is called before the first frame update

    public AIPath aiPath;
    

    // Update is called once per frame

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2.543151f, 2.893967f, 1f);

        }else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(2.543151f, 2.893967f, 1f);
        }
    }
}
