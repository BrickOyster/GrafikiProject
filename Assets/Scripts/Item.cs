using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType 
    {
        Money,
        Disguise,
        RedBlock,
        BlueBlock,
        YellowBlock,
        MedKit,
    }

    public ItemType itemType;

    public Sprite GetSprite(){
        switch (itemType) {
            default:
            case ItemType.Money:        return ItemAssets.Instance.moneySprite;
            case ItemType.Disguise:     return ItemAssets.Instance.disguiseSprite;
            case ItemType.RedBlock:     return ItemAssets.Instance.redBlockSprite;
            case ItemType.BlueBlock:    return ItemAssets.Instance.blueBlockSprite;
            case ItemType.YellowBlock:  return ItemAssets.Instance.yellowBlockSprite;
            case ItemType.MedKit:       return ItemAssets.Instance.medKitSprite;
        }
    }
}
