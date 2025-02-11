using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    public Item itemData;
    public Image itemIcon;

    private void Start()
    {
        if(itemData != null)
        {

            if(itemIcon != null)
            {
                itemIcon.sprite =  itemData.icon;
            }
        }
    }

}
