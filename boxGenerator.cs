using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// boxGenerator attach to game Manager object in heirarcy window and call in game start button
public class boxGenerator : MonoBehaviour
{
    public GameObject boxPrefab;
    private float xPos;
    private float yPos;

    public Transform boxParent;
    public GameObject[] boxInfo;
    int boxNumber = 0;

    // start button intractable
    public Button startbutton;
    public Button ResultButton;

    public bool custom = false;
    public bool ssReminder = false;
    public GameObject ssReminderPanel;
    
    public void boxIns()
    {
        if (PlayerPrefs.GetString("selectedsampling", "random") == "random")
            RandomSampling();
        
        else if (PlayerPrefs.GetString("selectedsampling", "random") == "startified")
        {

        }
        else if (PlayerPrefs.GetString("selectedsampling", "random") == "custom")
            CustomSampling();
    }

    public void RandomSampling()
    {
        for (int i = 0; i < 12; i++)
        {
            if (i == 0)
            {
                xPos = Random.Range(-700 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), -350 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-450 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), -150 - (PlayerPrefs.GetInt("boxsizeY",10) / 2));
            }
            else if (i == 1)
            {
                xPos = Random.Range(-350 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 0 -(PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-450 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), -150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 2)
            {
                xPos = Random.Range(0 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 350 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-450 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), -150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 3)
            {
                xPos = Random.Range(350 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 700 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-450 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), -150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 4)
            {
                xPos = Random.Range(-700 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), -350 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 5)
            {
                xPos = Random.Range(-350 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 0 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 6)
            {
                xPos = Random.Range(0 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 350 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 7)
            {
                xPos = Random.Range(350 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 700 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(-150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 150 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 8)
            {
                xPos = Random.Range(-700 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), -350 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 450 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 9)
            {
                xPos = Random.Range(-350 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 0 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 450 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 10)
            {
                xPos = Random.Range(0 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 350 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 450 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            else if (i == 11)
            {
                xPos = Random.Range(350 + (PlayerPrefs.GetInt("boxsizeX", 10) / 2), 700 - (PlayerPrefs.GetInt("boxsizeX", 10) / 2));
                yPos = Random.Range(150 + (PlayerPrefs.GetInt("boxsizeY", 10) / 2), 450 - (PlayerPrefs.GetInt("boxsizeY", 10) / 2));
            }
            Vector3 pos = new Vector3(xPos, yPos, 0);
            GameObject box = Instantiate(boxPrefab, pos, Quaternion.identity);
            box.transform.SetParent(boxParent, false);
            box.GetComponent<collisionDetection>().BoxName.text = (i + 1).ToString();
            boxInfo[i] = box;
            box.transform.localScale = new Vector3(PlayerPrefs.GetInt("boxsizeX", 10) * 2.5f, PlayerPrefs.GetInt("boxsizeY", 10) * 2.5f, 0);
            ResultScript.RS.boxes[i] = box;
        }
        startbutton.interactable = false;
        ResultButton.interactable = true;
        ssReminder = true;
    }

    public void CustomSampling()
    {
        custom = true;
        startbutton.interactable = false;
    }



    private void Update()
    {
        if (boxNumber < 12 && custom)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(myRay.origin, myRay.direction, Mathf.Infinity);

                GameObject box = Instantiate(boxPrefab, hit.point, Quaternion.identity);
                box.transform.SetParent(boxParent, false);
                box.GetComponent<collisionDetection>().BoxName.text = (boxNumber + 1).ToString();
                boxInfo[boxNumber] = box;
                box.transform.localScale = new Vector3(PlayerPrefs.GetInt("boxsizeX", 10) * 2.5f, PlayerPrefs.GetInt("boxsizeY", 10) * 2.5f, 0);
                print(PlayerPrefs.GetInt("boxsizeX", 10));
                ResultScript.RS.boxes[boxNumber] = box;

                boxNumber++;

                if (boxNumber == 12)
                {
                    ResultButton.interactable = true;
                    ssReminder = true;
                }
            }
        }
        if (ssReminder)
        {
            ssReminderPanel.SetActive(true);

            ssReminder = false;
        }
    }
}
