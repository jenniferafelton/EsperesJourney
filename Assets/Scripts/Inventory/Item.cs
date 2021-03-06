﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Sword,
        Shield,
        ManaPotion,
        Key,
        Coin,
        Document,
    }

    public ItemType itemType;
    public int amount;
    public Dialogue documentDialogue;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin: return ItemAssets.Instance.CoinSprite;
            case ItemType.Key: return ItemAssets.Instance.KeySprite;
            case ItemType.Document: return ItemAssets.Instance.DocumentSprite;
            case ItemType.ManaPotion: return ItemAssets.Instance.ManaPotionSprite;
            case ItemType.Sword: return ItemAssets.Instance.SwordSprite;
            case ItemType.Shield: return ItemAssets.Instance.ShieldSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
                //not stackable
            case ItemType.Sword:
            case ItemType.Shield:
            case ItemType.Document:
            case ItemType.Key:
                return false;
                //stackable
            case ItemType.ManaPotion:
            case ItemType.Coin:
                return true;
        }
    }
}
