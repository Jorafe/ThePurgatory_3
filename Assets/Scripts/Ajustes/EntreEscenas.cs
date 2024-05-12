using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreEscenas : MonoBehaviour
{
    public static EntreEscenas instance; 

    private void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsOfType<EntreEscenas>();

        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}