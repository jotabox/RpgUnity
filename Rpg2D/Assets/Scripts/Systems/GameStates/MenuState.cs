using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IGameState
{
    public void Enter()
    {
        Debug.Log("entrando no Menu State");
        //carrega a cenado menu. Mostrar Ui etc...
    }

    public void Exit()
    {
        Debug.Log("Saindo do Menu State");
        //limpa recursos do menu
    }

    public void Update()
    {
       //logica de atualização do menu
    }
}
