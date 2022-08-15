using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class settingPanel : MonoBehaviour
{
    public InputField inputQuadX;
    public InputField inputQuadY;
    public Text textQuad;

    public GameObject settingPanelOff;

    public Text getBoxSize;

    public GameObject ExitPanel;

    public Button[] samplingButtons;
    public GameObject[] selectedSamplingImg;

    public GameObject visualiseCheckImg;

    public Image ssImage;
    public Button ssButton;

    public bool visualiseClicked = false;
    public bool samplingChanged = false;
    public string newSampling;

    void Update()
    {
        textQuad.text = PlayerPrefs.GetInt("boxsizeX", 10).ToString() + "m" + " x " + PlayerPrefs.GetInt("boxsizeY", 10).ToString() + "m"; // change boxsize value display

        getBoxSize.text = textQuad.text;

        if (Input.GetKeyDown(KeyCode.Escape))
            ExitPanel.SetActive(true);

        if (newSampling == "random")
        {
            samplingButtons[0].interactable = false;
            samplingButtons[1].interactable = false;
            samplingButtons[2].interactable = true;
            selectedSamplingImg[0].SetActive(true);
            selectedSamplingImg[1].SetActive(false);
            selectedSamplingImg[2].SetActive(false);
        }
        else if (newSampling == "startified")
        {
            samplingButtons[0].interactable = true;
            samplingButtons[1].interactable = false;
            samplingButtons[2].interactable = true;
            selectedSamplingImg[0].SetActive(false);
            selectedSamplingImg[1].SetActive(true);
            selectedSamplingImg[2].SetActive(false);
        }
        else if (newSampling == "custom")
        {
            samplingButtons[0].interactable = true;
            samplingButtons[1].interactable = false;
            samplingButtons[2].interactable = false;
            selectedSamplingImg[0].SetActive(false);
            selectedSamplingImg[1].SetActive(false);
            selectedSamplingImg[2].SetActive(true);
        }

        if (visualiseClicked)
            visualiseCheckImg.SetActive(true);
        else
            visualiseCheckImg.SetActive(false);
    }

    public void OpenSettings()
    {
        if (PlayerPrefs.GetInt("visualise", 1) == 1)
            visualiseClicked = true;
        else
            visualiseClicked = false;

        newSampling = PlayerPrefs.GetString("selectedsampling", "random");
    }

    public void visualiseSpeciesButton()
    {
        if (visualiseClicked)
            visualiseClicked = false;
        else
            visualiseClicked = true;
    }

    public void MultiplxerButton()
    {
        if (PlayerPrefs.GetInt("boxsizeX", 10) <= 10 && PlayerPrefs.GetInt("boxsizeY", 10) <= 10)
        {
            PlayerPrefs.SetInt("boxsizeX", 20);
            PlayerPrefs.SetInt("boxsizeY", 10);
        }
        else if (PlayerPrefs.GetInt("boxsizeX", 10) <= 20 && PlayerPrefs.GetInt("boxsizeY", 10) <= 10)
        {
            PlayerPrefs.SetInt("boxsizeX", 20);
            PlayerPrefs.SetInt("boxsizeY", 20);
        }
        else if (PlayerPrefs.GetInt("boxsizeX", 10) <= 20 && PlayerPrefs.GetInt("boxsizeY", 10) <= 20)
        {
            PlayerPrefs.SetInt("boxsizeX", 50);
            PlayerPrefs.SetInt("boxsizeY", 20);
        }
        else if (PlayerPrefs.GetInt("boxsizeX", 10) <= 50 && PlayerPrefs.GetInt("boxsizeY", 10) <= 20)
        {
            PlayerPrefs.SetInt("boxsizeX", 50);
            PlayerPrefs.SetInt("boxsizeY", 50);
        }
        else if (PlayerPrefs.GetInt("boxsizeX", 10) <= 50 && PlayerPrefs.GetInt("boxsizeY", 10) <= 50)
        {
            PlayerPrefs.SetInt("boxsizeX", 10);
            PlayerPrefs.SetInt("boxsizeY", 10);
        }
    }

    public void samplingButton(string sampling)
    {
        newSampling = sampling;
    }

    public void CancelButton()
    {
        PlayerPrefs.SetInt("boxsizeX", 10);
        PlayerPrefs.SetInt("boxsizeY", 10);
        settingPanelOff.SetActive(false);
    }

    public void SaveSettingButton()
    {
        settingPanelOff.SetActive(false);

        int num;
        if (inputQuadX.text != "" || inputQuadY.text != "")
        {
            string s = inputQuadX.text;
            int.TryParse(s, out num);
            PlayerPrefs.SetInt("boxsizeX", num);
            s = inputQuadY.text;
            int.TryParse(s, out num);
            PlayerPrefs.SetInt("boxsizeY", num);
        }

        if (PlayerPrefs.GetInt("boxsizeX", 10) < 10)
            PlayerPrefs.SetInt("boxsizeX", 10);     
        if (PlayerPrefs.GetInt("boxsizeX", 10) > 50)
            PlayerPrefs.SetInt("boxsizeX", 50);     
     
        if (PlayerPrefs.GetInt("boxsizeY", 10) < 10)
            PlayerPrefs.SetInt("boxsizeY", 10);     
        if (PlayerPrefs.GetInt("boxsizeY", 10) > 50)
            PlayerPrefs.SetInt("boxsizeY", 50);

        if (visualiseClicked)
            PlayerPrefs.SetInt("visualise", 1);
        else
            PlayerPrefs.SetInt("visualise", 0);

        if (PlayerPrefs.GetInt("visualise", 1) == 1)
            for (int i = 0; i < gameManager.GM.total; i++)
                gameManager.GM.TreesObjs[i].GetComponent<SpriteRenderer>().enabled = true;
        else
            for (int i = 0; i < gameManager.GM.total; i++)
                gameManager.GM.TreesObjs[i].GetComponent<SpriteRenderer>().enabled = false;

        PlayerPrefs.SetString("selectedsampling", newSampling);
    }

    public void ResetSettings()
    {
        PlayerPrefs.SetInt("boxsizeX", 10);
        PlayerPrefs.SetInt("boxsizeY", 10);
        PlayerPrefs.SetInt("visualise", 0);
        PlayerPrefs.SetString("selectedsampling", "random");
        PlayerPrefs.SetInt("treeCount0", 148);
        PlayerPrefs.SetInt("treeCount1", 147);
        PlayerPrefs.SetInt("treeCount2", 147);
        PlayerPrefs.SetInt("treeCount3", 147);
        PlayerPrefs.SetInt("treeCount4", 147);
        PlayerPrefs.SetInt("treeCount5", 147);
        PlayerPrefs.SetInt("treeCount6", 147);
        PlayerPrefs.SetInt("treeCount7", 147);
        PlayerPrefs.SetInt("treeCount8", 147);
        PlayerPrefs.SetInt("treeCount9", 147);
        PlayerPrefs.SetInt("treeCount10", 147);
        PlayerPrefs.SetInt("treeCount11", 147);
        PlayerPrefs.SetInt("treeCount12", 147);
        PlayerPrefs.SetInt("treeCount13", 147);
        PlayerPrefs.SetInt("treeCount14", 147);
        PlayerPrefs.SetInt("treeCount15", 147);
        PlayerPrefs.SetInt("treeCount16", 147);
        //PlayerPrefs.SetString("treename0", "Tree1");
        //PlayerPrefs.SetString("treename1", "Tree2");
        //PlayerPrefs.SetString("treename2", "Tree3");
        //PlayerPrefs.SetString("treename3", "Tree4");
        //PlayerPrefs.SetString("treename4", "Tree5");
        //PlayerPrefs.SetString("treename5", "Tree6");
        //PlayerPrefs.SetString("treename6", "Tree7");
        //PlayerPrefs.SetString("treename7", "Tree8");
        //PlayerPrefs.SetString("treename8", "Tree9");
        //PlayerPrefs.SetString("treename9", "Tree10");
        //PlayerPrefs.SetString("treename10", "Tree11");
        //PlayerPrefs.SetString("treename11", "Tree12");
        //PlayerPrefs.SetString("treename12", "Tree13");
        //PlayerPrefs.SetString("treename13", "Tree14");
        //PlayerPrefs.SetString("treename14", "Tree15");
        //PlayerPrefs.SetString("treename15", "Tree16");
        //PlayerPrefs.SetString("treename16", "Tree17");
        SceneManager.LoadScene(0);
    }

    public void ScreenShotButton()
    {
        ssButton.interactable = false;
        StartCoroutine(TakeScreenshotAndShare());
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        Sprite s = Sprite.Create(ss, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));
        ssImage.sprite = s;

        PlayerPrefs.SetInt("screenshotnumber", PlayerPrefs.GetInt("screenshotnumber", 0) + 1);
        int num = PlayerPrefs.GetInt("screenshotnumber", 0);
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Screenshot" + num + ".png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());
        print(filePath);

        ssImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        ssImage.gameObject.SetActive(false);
        ssButton.interactable = true;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
