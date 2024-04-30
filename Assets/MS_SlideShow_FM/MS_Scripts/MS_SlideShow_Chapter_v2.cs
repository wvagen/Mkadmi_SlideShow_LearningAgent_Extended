using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MS_SlideShow_Chapter_v2 : MonoBehaviour
{
    [SerializeField]
    private Color cellColOdd, cellColEven;

    [SerializeField]
    private Color textCellColOdd, textCellColEven;

    public GameObject row, cell;
    public Transform columnContainer;
    public Text titleTxt;

    int cellSpawnedCount;
    string textValue;

    List<GameObject> rowsSpawned = new List<GameObject>();
    List<MS_SlideShow_Chapter_v2_Cell> cellsSpawned = new List<MS_SlideShow_Chapter_v2_Cell>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        ResetEverything();
        SpawnBehavior();

        StartCoroutine(StartAnimationProgressly());
    }

    void ResetEverything()
    {
        if (rowsSpawned.Count != 0)
        {
            foreach (GameObject g in rowsSpawned) Destroy(g);
        }
        columnContainer.GetComponent<VerticalLayoutGroup>().enabled = true;
        rowsSpawned = new List<GameObject>();
        cellsSpawned = new List<MS_SlideShow_Chapter_v2_Cell>();
        cellSpawnedCount = 0;
        StopAllCoroutines();
    }

    void SpawnBehavior()
    {
        textValue = titleTxt.text;
        titleTxt.enabled = false;

        string[] textPieces = textValue.Split(' ');

        for (int i = 0; i < textPieces.Length; i++)
        {
            Transform rowContainer = Instantiate(row, columnContainer).transform;
            rowsSpawned.Add(rowContainer.gameObject);
            for (int j = 0; j < textPieces[i].Length; j++)
            {
                MS_SlideShow_Chapter_v2_Cell cellScript = 
                    Instantiate(cell, rowContainer).GetComponent<MS_SlideShow_Chapter_v2_Cell>();

                if (cellSpawnedCount % 2 == 0)
                {
                    cellScript.SetMe(cellColOdd, textCellColOdd, textPieces[i][j].ToString());
                }
                else
                {
                    cellScript.SetMe(cellColEven, textCellColEven, textPieces[i][j].ToString());
                }
                cellsSpawned.Add(cellScript);
                cellSpawnedCount++;
            }
        }
    }

    IEnumerator StartAnimationProgressly()
    {
        yield return new WaitForEndOfFrame();

        columnContainer.GetComponent<VerticalLayoutGroup>().enabled = false;

        for (int i = 0; i < rowsSpawned.Count; i++)
        {
            rowsSpawned[i].GetComponent<HorizontalLayoutGroup>().enabled = false;
        }
        for (int i = 0; i < cellsSpawned.Count; i++)
        {
            cellsSpawned[i].SpawnAnim();
            yield return new WaitForSeconds(0.1f);
        }
    } 

}
