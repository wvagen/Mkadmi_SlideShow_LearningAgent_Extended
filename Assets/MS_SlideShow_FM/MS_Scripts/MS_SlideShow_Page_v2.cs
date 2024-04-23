using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MS_SlideShow_Page_v2 : MonoBehaviour
{
    public Text pageNumberTxt;

    private List<Element_Script_v2> pageElements = new List<Element_Script_v2>();

    private void OnEnable()
    {
        ResetElements();
        Set_Elements();
        StartCoroutine(StartAnimationAfterWhile());
    }

    void ResetElements()
    {
        StopAllCoroutines();
        pageElements = new List<Element_Script_v2>();
    }

    void Set_Elements()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Element_Script_v2>() != null)
            {
                pageElements.Add(transform.GetChild(i).GetComponent<Element_Script_v2>());
            }
        }
    }

    IEnumerator StartAnimationAfterWhile()
    {
        for (int i = 0; i < pageElements.Count; i++)
        {
            pageElements[i].StartAnimation();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void Set_Me(int myPageIndex)
    {
        if (pageNumberTxt != null)
        {
            pageNumberTxt.text = myPageIndex.ToString();
        }
    }

    public void Set_Active(bool isShowing)
    {
        gameObject.SetActive(isShowing);
    }
}
