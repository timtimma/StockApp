using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingStockCell : MonoBehaviour {

    private Button editBtn;
    private Text stockIDText;
    private Text marketPriceText;
    private Text targetPriceText;
    private Text stopPriceText;
    private Text durationText;
    private Image durationImg;


    private TradingStockCell data;

    public void Initial()
    {

    }

    public void Refresh(TradingStockCell _data)
    {
        data = _data;

        gameObject.SetActive(true);
    }
}
