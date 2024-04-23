using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MS_SlideShow_Chapter_v2_Cell : MonoBehaviour
{
    public Text letterInsideTxt;
    public Image myImg;

    Vector2 initScale;

    float floatSpeed = 5;

    public void SetMe(Color cellCol, Color textCol, string letter)
    {
        myImg.color = cellCol;
        letterInsideTxt.text = letter;
        letterInsideTxt.color = textCol;

        myImg.enabled = false;
        letterInsideTxt.enabled = false;

        initScale = transform.localScale;
    }

    public void SpawnAnim()
    {
        StartCoroutine(Spawn_Anim());
    }

    IEnumerator Spawn_Anim()
    {
        Vector2 currentScale = initScale;
        myImg.enabled = true;
        letterInsideTxt.enabled = true;

        transform.localScale = Vector2.zero;
        currentScale = transform.localScale;

        while (transform.localScale.x < initScale.x)
        {
            float randSpeed = Random.Range(2f, floatSpeed);
            currentScale.x += Time.deltaTime * randSpeed;
            currentScale.y += Time.deltaTime * randSpeed;

            transform.localScale = currentScale;
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = initScale;
    }
}
