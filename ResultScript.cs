using System;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public static ResultScript RS;

    public Text[] ResultTreeNames;
    public Text[] Box1Result;
    public Text[] Box2Result;
    public Text[] Box3Result;
    public Text[] Box4Result;
    public Text[] Box5Result;
    public Text[] Box6Result;
    public Text[] Box7Result;
    public Text[] Box8Result;
    public Text[] Box9Result;
    public Text[] Box10Result;
    public Text[] Box11Result;
    public Text[] Box12Result;

    public GameObject[] boxes;

    [Header("CSV Settings")]
    public string fileName = "";

    // Start is called before the first frame update
    void Start()
    {
        RS = this;
        PlayerPrefs.SetInt("resultnumber", PlayerPrefs.GetInt("resultnumber", 0) + 1);
        int num = PlayerPrefs.GetInt("resultnumber", 0);
        fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Result" + num + ".csv";
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 17; i++)
        {
            ResultTreeNames[i].text = PlayerPrefs.GetString("treename" + i, "");

            if (boxes[0] != null)
                Box1Result[i].text = boxes[0].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[1] != null)
                Box2Result[i].text = boxes[1].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[2] != null)
                Box3Result[i].text = boxes[2].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[3] != null)
                Box4Result[i].text = boxes[3].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[4] != null)
                Box5Result[i].text = boxes[4].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[5] != null)
                Box6Result[i].text = boxes[5].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[6] != null)
                Box7Result[i].text = boxes[6].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[7] != null)
                Box8Result[i].text = boxes[7].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[8] != null)
                Box9Result[i].text = boxes[8].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[9] != null)
                Box10Result[i].text = boxes[9].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[10] != null)
                Box11Result[i].text = boxes[10].GetComponent<collisionDetection>().treeCount[i].ToString();
            if (boxes[11] != null)
                Box12Result[i].text = boxes[11].GetComponent<collisionDetection>().treeCount[i].ToString();
        }
    }

    public void WriteCSV()
    {
        if (boxes[0] != null)
        {
            TextWriter tw = new StreamWriter(fileName, false);
            tw.WriteLine("TreeName, Quadrat 1, Quadrat 2, Quadrat 3, Quadrat 4, Quadrat 5, Quadrat 6, Quadrat 7, Quadrat 8, Quadrat 9, Quadrat 10, Quadrat 11, Quadrat 12");
            tw.Close();

            tw = new StreamWriter(fileName, true);
            for (int i = 0; i < 17; i++)
            {
                tw.WriteLine(ResultTreeNames[i].text + ", " + Box1Result[i].text + ", " + Box2Result[i].text + ", " + Box3Result[i].text
                    + ", " + Box4Result[i].text + ", " + Box5Result[i].text + ", " + Box6Result[i].text + ", " + Box7Result[i].text
                    + ", " + Box8Result[i].text + ", " + Box9Result[i].text + ", " + Box10Result[i].text + ", " + Box11Result[i].text
                    + ", " + Box12Result[i].text);
            }
            tw.Close();
        }
    }
}
