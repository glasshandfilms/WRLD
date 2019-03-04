using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class interactInfo : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    public int number = 0;
    public TMP_Text infoText;
    [SerializeField]
    private string description = "";
    

    private void Awake()
    {
        
    }

    void Start()
    {
        

        Debug.Log("Number is currently: " + number);
    }

    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                infoText.text = (string)this.description;
                StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("clickedSphere " + description);

                
                
                
            }
        }
    }

    

    IEnumerator ScaleMe(Transform objTr)
    {
        objTr.localScale *= 1.2f;
        yield return new WaitForSeconds(0.5f);
        objTr.localScale /= 1.2f;
    }

}
