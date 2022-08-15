using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// collisionDetection script attach to 
public class collisionDetection : MonoBehaviour
{
    public int treeCounter = 0;
    public int[] treeCount;
    public Text BoxName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "treeTag")
        {
            treeCounter++;

            if (collision.gameObject.name == PlayerPrefs.GetString("treename0", ""))
            {
                treeCount[0]++;
            }   
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename1", ""))
            {
                treeCount[1]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename2", ""))
            {
                treeCount[2]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename3", ""))
            {
                treeCount[3]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename4", ""))
            {
                treeCount[4]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename5", ""))
            {
                treeCount[5]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename6", ""))
            {
                treeCount[6]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename7", ""))
            {
                treeCount[7]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename8", ""))
            {
                treeCount[8]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename9", ""))
            {
                treeCount[9]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename10", ""))
            {
                treeCount[10]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename11", ""))
            {
                treeCount[11]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename12", ""))
            {
                treeCount[12]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename13", ""))
            {
                treeCount[13]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename14", ""))
            {
                treeCount[14]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename15", ""))
            {
                treeCount[15]++;
            }
            else if (collision.gameObject.name == PlayerPrefs.GetString("treename16", ""))
            {
                treeCount[16]++;
            }
        }
    }
}
