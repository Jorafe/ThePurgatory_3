using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject[] monedas;

    void Start()
    {
        foreach (GameObject moneda in monedas)
        {
            moneda.SetActive(false);
        }
    }

    public void ActivarMoneda(int indice)
    {
        Debug.Log("Activando moneda en índice: " + indice);

        if (indice >= 0 && indice < monedas.Length)
        {
            monedas[indice].SetActive(true);
        }
    }

}
