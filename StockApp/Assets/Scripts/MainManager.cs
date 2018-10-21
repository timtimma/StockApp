using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	public static MainManager Current;

    //Main Page Component
    public Button maskBtn;

    public GameObject gannObj;
    public GameObject menuTopGroupObj;

    //variable
    public PageEnum currPage = PageEnum.MainMenu;
    private ArrayList needCloseObjList = new ArrayList();


    private void Awake()
    {
        if (Current == null)
            Current = this;

        maskBtn.onClick.AddListener(() => CloseAllNeedObjs());

    }

    public void AddCloseObjs(ArrayList list, bool needMask)
    {
        for(int i = 0; i < list.Count; i++)
        {
            needCloseObjList.Add((GameObject) list[i]);
        }

        if (needMask)
        {
            maskBtn.gameObject.SetActive(true);
            needCloseObjList.Add(maskBtn.gameObject);
        }
    }

    private void CloseAllNeedObjs()
    {
        for (int i = 0; i < needCloseObjList.Count; i++)
        {
            ((GameObject)needCloseObjList[i]).SetActive(false);
        }

        needCloseObjList = new ArrayList();
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
        iTween.ScaleTo(nextObj, new Vector3(1, 1, 1), 0.2f);
        yield return new WaitForSeconds(0.2f);

        beforeObj.transform.localScale = new Vector3(1, 1, 1);
        currPage = nextPage;

        if (callback != null)
            callback();
    }

    public GameObject GetObjByPageEnum(PageEnum page)
    {
        switch (page)
        {
            case PageEnum.MainMenu:
                return menuTopGroupObj;
            case PageEnum.Gann:
                return gannObj;
            default:
                return null;
        }
    }

    public void SelectPage(PageEnum page)
    {
        if (page == currPage)
            return;

        StartCoroutine(SwitchPage(currPage, page));
    }

}
