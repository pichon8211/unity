using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mouse2 : MonoBehaviour
{
    [SerializeField] Material lineMaterial;
    [SerializeField] Color lineColor;
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;    
    List<LineRenderer> lineRenderers;

    GameObject clicked;
    private HashSet<GameObject> mylist=new HashSet<GameObject>();
    void Start()
    {
         lineRendererList = new List<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            _addLineObject();
            clicked = null;
 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
 
            if (Physics.Raycast(ray, out hit)) {
                clicked = hit.collider.gameObject;
            }
           //Debug.Log(clicked);
            if(clicked!=null)mylist.Add(clicked);
            if() 
         
    }
    void _addLineObject(){
        GameObject lineobj = new GameObject();
        lineobj.AddComponent<LineRenderer>();
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        lineObj.transform.SetParent(transform);
        _initRenderers();
    }
     void _initRenderers(){
         lineRenderers.Last().positionCount = 0;        
        lineRenderers.Last().material = lineMaterial;        
        lineRenderers.Last().material.color = lineColor;        
        lineRenderers.Last().startWidth = lineWidth;
        lineRenderers.Last().endWidth = lineWidth;
     }
}
}

