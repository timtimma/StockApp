using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //Main Menu Component
    public GameObject menuTopGroupObj;
    public Button maskBtn;
    //Bottom Group
    public Button toolBtn;
    public Button mainMenuBtn;

    //mini popups
    public GameObject toolPopupObj;
    public Button gannBtn;

    //Other Component
    public GameObject gannObj;

    //variable
    public PageEnum currPage = PageEnum.MainMenu;
    private ArrayList needCloseObjList = new ArrayList();

    private void Awake()
    {
        maskBtn.onClick.AddListener(() => CloseAllNeedObjs());

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
        maskBtn.gameObject.SetActive(true);

        needCloseObjList.Add(targetObj);
        needCloseObjList.Add(maskBtn.gameObject);
    }

    private void CloseAllNeedObjs()
    {
        for(int i = 0; i < needCloseObjList.Count; i++)
        {
            ((GameObject)needCloseObjList[i]).SetActive(false);
        }

        needCloseObjList = new ArrayList();
    }

    public void SelectPage(PageEnum page)
    {
        if (page == currPage)
            return;

        StartCoroutine( SwitchPage(currPage, page));
    }

    public IEnumerator SwitchPage(PageEnum beforePage, PageEnum nextPage, Action callback = null)
    {
        GameObject beforeObj = GetObjByPageEnum(beforePage);
        iTween.ScaleTo(beforeObj, new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        beforeObj.SetActive(false);
        CloseAllNeedObjs();

        GameObject nextObj = GetObjByPageEnum(nextPage);
        nextObj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        nextObj.SetActive(true);
        iTween.ScaleTo(nextObj, new Vector3(1,1,1), 0.2f);
        yield return new WaitForSeconds(0.2f);

        beforeObj.transform.localScale = new Vector3(1,1,1);
        currPage = nextPage;

        if (callback != null)
            callback();
    }

    public GameObject GetObjByPageEnum(PageEnum page)
    {
        switch(page)
        {
            case PageEnum.MainMenu:
                return menuTopGroupObj;
            case PageEnum.Gann:
                return gannObj;
            default:
                return null;
        }
    }
}
