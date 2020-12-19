using System;
using System.Collections;
using System.Collections.Generic;
using Minigames;
using SaveLoadSystem;
using Shop;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopPanelScript : MonoBehaviour
{
    
    public Image minigameIcon;
    public TextMeshProUGUI description;
    public int price;
    public TextMeshProUGUI priceText;
    public Status status;
    public Button buyButton;
    public GameObject soldPanel;

    private ShopController shopController;
    private MinigameObject minigameObjectForMod;
    public void SetUpShopPanel(ShopController shopController, MinigameObject minigameObject, int gold)
    {
        this.shopController = shopController;
        this.minigameIcon.sprite = minigameObject.WeaponSprite;
        this.description.text = minigameObject.description;
        this.price = minigameObject.price;
        this.priceText.text = "Price: " + price.ToString();
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

    public void PressedBuyButton()
    {
        if (price < shopController.GetGold())
        {
            soldPanel.SetActive(true);
            shopController.itemBouth(price);
            minigameObjectForMod.status = Status.Have;
        }
    }


}
