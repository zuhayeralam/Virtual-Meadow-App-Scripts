using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// buttonController script attach to Plus Minus Button of species panel plus minus buttons

public class buttonController : MonoBehaviour
{
    public bool isButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(  isButtonPressed == true)
        {

            GetComponent<Button>().onClick.Invoke();
        }
        
    }
    public void OnButtonDown()
    {
        StartCoroutine(waitAndStart());
    }

    public void OnButtonUp()
    {
        isButtonPressed = false;
        StopAllCoroutines();
    }


    IEnumerator waitAndStart()
    {
        yield return new WaitForSeconds(0.5f);
        isButtonPressed = true;

    }
}
