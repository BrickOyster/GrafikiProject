using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
    }

    public Sprite moneySprite;    
    public Sprite disguiseSprite; 
    public Sprite redBlockSprite; 
    public Sprite blueBlockSprite;    
    public Sprite yellowBlockSprite;  
    public Sprite medKitSprite;   
}
