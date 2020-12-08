using System;
using System.Collections;
using System.Collections.Generic;
using Minigames;
using SaveLoadSystem;
using Shop;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelScript : MonoBehaviour
{
    
    public Image minigameIcon;
    public String description;
    public int price;
    public Status status;
    public Button buyButton;
    public GameObject soldPanel;

    private ShopController shopController;
    private MinigameObject minigameObjectForMod;
    public void SetUpShopPanel(ShopController shopController, MinigameObject minigameObject, int gold)
    {
        this.shopController = shopController;
        this.minigameIcon.sprite = minigameObject.WeaponSprite;
        this.description = minigameObject.description;
        this.price = minigameObject.price;
        this.status = minigameObject.status;
        this.minigameObjectForMod = minigameObject;
        if (this.status == Status.Have)
        {
            soldPanel.SetActive(true);
        }else if (this.price <= gold)
        {
            buyButton.interactable = true;
        }
        

    }

    
}
