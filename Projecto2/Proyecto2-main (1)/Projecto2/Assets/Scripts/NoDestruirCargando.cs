using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruirCargando : MonoBehaviour
{
    public static NoDestruirCargando instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
    }

    //Esto va en cualquier otro codigo, como un gameManager :D
    //NoDestruirCargando.instance.GetCoins() (GetCoins() es un ejemplo :D)
}
