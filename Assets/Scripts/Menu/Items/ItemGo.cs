using UnityEngine;
using UnityEngine.UI;

public class ItemGo : MonoBehaviour
{
    public Text[] BoostLot;
    void Start()
    {
        BoostLotAll();
    }

    void Update()
    {
        BoostLotAll();
    }
    private void BoostLotAll()
    {
        if (PlayerPrefs.HasKey("Wings"))
            BoostLot[0].text = $"{PlayerPrefs.GetInt("Wings")}";
        else
            BoostLot[0].text = "0";
        if (PlayerPrefs.HasKey("x2"))
            BoostLot[1].text = $"{PlayerPrefs.GetInt("x2")}";
        else
            BoostLot[1].text = "0";
        if (PlayerPrefs.HasKey("Time"))
            BoostLot[2].text = $"{PlayerPrefs.GetInt("Time")}";
        else
            BoostLot[2].text = "0";
    }
}
