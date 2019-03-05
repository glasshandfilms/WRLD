using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interactInfo : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public int number = 0;
    public TMP_Text infoText;
    [SerializeField]
    private string description = "";

    //Added
    public Collider col;

    private void Awake()
    {
        // Set in inspector or let it set here on Awake
        if (col == null)
        {
            col = gameObject.GetComponent<Collider>();
        }
    }

    void Start()
    {

        Debug.Log("Number is currently: " + number + "\n");

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down" + "\n");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // Can use a Tag if you want, but not really needed unless you want to cull raycasts more
                //if (hit.collider.gameObject.tag == "Target" && hit.collider == col)
                if (hit.collider == col)
                {
                    //Added null ref check because I don't have the TMP component
                    if (infoText != null)
                    {
                        infoText.text = (string)this.description;
                    }
                    StartCoroutine(ScaleMe(hit.transform));
                    Debug.Log("clickedSphere " + col.gameObject.name + " " + description + "\n");
                }
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
