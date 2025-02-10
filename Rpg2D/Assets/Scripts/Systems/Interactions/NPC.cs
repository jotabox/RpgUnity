using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public void Interact()
    {
       Debug.Log("Interagiu com Npc!");
        //chamar aqui sistema de diálogo
    }
}
