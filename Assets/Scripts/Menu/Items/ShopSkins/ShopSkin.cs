using System.Collections.Generic;
using UnityEngine;

public class ShopSkin : MonoBehaviour
{
    public SpriteRenderer player;
    public List<Sprite> skinsBuy = new List<Sprite>();
    public List<Sprite> skins = new List<Sprite>();
    public GameObject[] textPrice;
    private int coin;

    void Start()
    {
        for (int i = 0; i < skins.Count; i++)
        {
            if (PlayerPrefs.HasKey("IconShop"))
            {
                skins[PlayerPrefs.GetInt("IconShop" + i)] = skinsBuy[PlayerPrefs.GetInt("IconShop" + i)];
                skinsBuy[PlayerPrefs.GetInt("IconShop" + i)] = null;
                player.sprite = skins[PlayerPrefs.GetInt("IconShops")];
            }
            else
            {
                textPrice[PlayerPrefs.GetInt("IconShop" + i)].SetActive(false);
                skins[i + 1] = skinsBuy[i + 1];
                skinsBuy[PlayerPrefs.GetInt("IconShop" + i)] = null;
                player.sprite = skins[PlayerPrefs.GetInt("IconShops")];
            }
        }
    }
    public void ShowTexture(int selectedIndex)
    {
        for (int i = 0; i < skinsBuy.Count; i++)
        {
            if (selectedIndex == i)
            {
                if (skinsBuy[selectedIndex] != null)
                {
                    if (PlayerPrefs.GetInt("CoinsAll") >= coin)
                    {
                        ConfigurableParameters.coinAll = PlayerPrefs.GetInt("CoinsAll") - coin;
                        PlayerPrefs.SetInt("CoinsAll", ConfigurableParameters.coinAll);
                        PlayerPrefs.SetInt("IconShop" + i, selectedIndex);
                        textPrice[selectedIndex].SetActive(false);
                        skins[i] = skinsBuy[selectedIndex];
                        player.sprite = skinsBuy[selectedIndex];
                        skinsBuy[selectedIndex] = null;
                        PlayerPrefs.SetInt("IconShop" + i, selectedIndex);
                        PlayerPrefs.SetInt("IconShops", selectedIndex);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    for (int j = 0; j < skins.Count; j++)
                    {
                        if (selectedIndex == j)
                        {
                            player.sprite = skins[selectedIndex];
                            PlayerPrefs.SetInt("IconShops", selectedIndex);
                            PlayerPrefs.Save();
                        }
                    }
                }
            }
        }
    }

    public void Price(int price)
    {
        coin = price;
    }

}
