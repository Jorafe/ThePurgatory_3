using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
   
   public static GameManager Instance { get; private set; }

   public HUD hud;

   public int moneditas;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destruye la instancia duplicada
        }
    }
    public void ConseguirMoneda()
   {
        if (moneditas == 6)
        {
            Debug.Log("Hay 6 monedas");
            return;
        }
        else
        {
            hud.ActivarMoneda(moneditas);
            moneditas += 1;
        }
        
   }


}
