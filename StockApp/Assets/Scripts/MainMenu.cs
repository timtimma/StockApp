using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //Bottom Group
    public Button toolBtn;
    public Button mainMenuBtn;

    //mini popups
    public GameObject toolPopupObj;
    public Button gannBtn;


    private void Awake()
    {
        toolBtn.onClick.AddListener(() => ClickBottomBtn(2));

        mainMenuBtn.onClick.AddListener(() => SelectPage( PageEnum.MainMenu));
        gannBtn.onClick.AddListener(() => SelectPage(PageEnum.Gann));
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickBottomBtn(int index)
    {
        /*
         * 1 = list
         * 2 = tool
         * 3 = figure
         * 4 = notes
         */
        GameObject targetObj = null;
        if(index == 2)
            targetObj = toolPopupObj;


        targetObj.transform.localScale = new Vector3(1, 0, 1);
        iTween.ScaleTo(targetObj, new Vector3(1, 1, 1), 0.2f);
        targetObj.SetActive(true);

        ArrayList closeList = new ArrayList();
        closeList.Add(targetObj);
        MainManager.Current.AddCloseObjs(closeList, true);
    }

    public void SelectPage(PageEnum page)
    {
        MainManager.Current.SelectPage(page);
    }

}
