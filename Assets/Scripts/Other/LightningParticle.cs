using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningParticle : MonoSingleton<LightningParticle>
{
    public void SetPositionsParticle(GameObject[] gameObjects)
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).position = gameObjects[i].transform.position;
        }
    }
}
