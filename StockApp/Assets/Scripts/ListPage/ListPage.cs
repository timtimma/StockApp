using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListPage : MonoBehaviour {

    //UI
    public ScrollRect scrollRect;
    public Image maskImg;
    
    //Cell Samples
    public TradingStockCell tradingCell;


    private void Awake()
    {
        tradingCell.gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
