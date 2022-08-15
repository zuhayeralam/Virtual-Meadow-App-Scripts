using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // for reload the scene

// gameManager Script attach to Game Manager object

public class gameManager : MonoBehaviour
{
    public static gameManager GM;

    public List<Transform> spawnPoints;
    public GameObject tree;
    public Transform treeParent;
    public Color[] treeColors;

    public int totalTreesAllowed;
    public Button[] plusMinusbutton;
    public int[] numOfTrees;
    public Text[] numOfTressText;
    public int total = 0;

    public InputField[] treeName;
    public List<GameObject> TreesObjs;

    [System.Serializable]
    public class TreeInfo
    {
        public List<GameObject> treeGroup;
    }
    public List<TreeInfo> TI;

    // Start is called before the first frame update
    void Start()
    {
        GM = this;

        if (PlayerPrefs.GetInt("treeCount0", 0) == 0)
            SetDefault();

        SpawnTrees();

        for (int i = 0; i < treeName.Length; i++)
        {
            treeName[i].text = PlayerPrefs.GetString("treename" + i, "");
        }
    }

    public void SpawnTrees()
    {
        //for (int i = 0; i < 17; i++)
        //{
        //    for (int j = 0; j < numOfTrees[i]; j++)
        //    {
        //        int random = Random.Range(0, spawnPoints.Count);
        //        GameObject Tree = Instantiate(tree, spawnPoints[random].position, Quaternion.identity);
        //        Tree.GetComponent<SpriteRenderer>().color = treeColors[i];
        //        float s = Random.Range(0.5f, 1.5f);
        //        Tree.transform.localScale = new Vector3(s, s, s);
        //        Tree.transform.SetParent(treeParent);
        //        spawnPoints.Remove(spawnPoints[random]);
        //        Tree.name = PlayerPrefs.GetString("treename" + i, "");
        //        TreesObjs.Add(Tree);
        //    }
        //}
        for (int i = 0; i < TI.Count; i++)
            for (int j = 0; j < TI[i].treeGroup.Count; j++)
                TI[i].treeGroup[j].name = PlayerPrefs.GetString("treename" + i, "");

        if (PlayerPrefs.GetInt("visualise", 1) == 1)
        {
            for (int i = 0; i < totalTreesAllowed; i++)
            {
                TreesObjs[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < totalTreesAllowed; i++)
            {
                TreesObjs[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (total < totalTreesAllowed)
        {
            for (int i = 0; i < plusMinusbutton.Length; i++)
            {
                plusMinusbutton[i].interactable = true;
            }
        }
        else
        {
            for (int i = 0; i < plusMinusbutton.Length; i++)
            {
                plusMinusbutton[i].interactable = false;
            }
        }

        for (int i = 0; i < numOfTressText.Length; i++)
        {
            numOfTrees[i] = PlayerPrefs.GetInt("treeCount" + i, 0);
            numOfTressText[i].text = numOfTrees[i].ToString();
        }
        countTotal();
    }

    public void PlusTreeButton(int tree)
    {
        if (total < totalTreesAllowed)
            PlayerPrefs.SetInt("treeCount" + tree, PlayerPrefs.GetInt("treeCount" + tree, 0) + 1);
    }
    
    public void MinusTreeButton(int tree)
    {
        if (PlayerPrefs.GetInt("treeCount" + tree, 0) > 0)
            PlayerPrefs.SetInt("treeCount" + tree, PlayerPrefs.GetInt("treeCount" + tree, 0) - 1);
    }

    public void countTotal()
    {
        total = 0;
        for (int i = 0; i < numOfTrees.Length; i++)
        {
            total += numOfTrees[i];
        }
    }

    public void SetDefault()
    {
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
        PlayerPrefs.SetString("treename0", "Tree1");
        PlayerPrefs.SetString("treename1", "Tree2");
        PlayerPrefs.SetString("treename2", "Tree3");
        PlayerPrefs.SetString("treename3", "Tree4");
        PlayerPrefs.SetString("treename4", "Tree5");
        PlayerPrefs.SetString("treename5", "Tree6");
        PlayerPrefs.SetString("treename6", "Tree7");
        PlayerPrefs.SetString("treename7", "Tree8");
        PlayerPrefs.SetString("treename8", "Tree9");
        PlayerPrefs.SetString("treename9", "Tree10");
        PlayerPrefs.SetString("treename10", "Tree11");
        PlayerPrefs.SetString("treename11", "Tree12");
        PlayerPrefs.SetString("treename12", "Tree13");
        PlayerPrefs.SetString("treename13", "Tree14");
        PlayerPrefs.SetString("treename14", "Tree15");
        PlayerPrefs.SetString("treename15", "Tree16");
        PlayerPrefs.SetString("treename16", "Tree17");
    }

    public void NameSet(int tree)
    {
        PlayerPrefs.SetString("treename" + tree, treeName[tree].text);
        treeName[tree].text = PlayerPrefs.GetString("treename" + tree, "");

        for (int j = 0; j < TI[tree].treeGroup.Count; j++)
            TI[tree].treeGroup[j].name = PlayerPrefs.GetString("treename" + tree, "");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
