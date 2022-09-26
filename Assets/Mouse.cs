using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameObject clicked;
    LineRenderer line;
    private HashSet<GameObject> mylist=new HashSet<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        var line =gameObject.AddComponent<LineRenderer>();
        this.line = GetComponent<LineRenderer>();
        this.line.startWidth = 0.1f;
        this.line.endWidth = 0.1f;
        this.line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
 
            clicked = null;
 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
 
            if (Physics.Raycast(ray, out hit)) {
                clicked = hit.collider.gameObject;
            }
 
            //Debug.Log(clicked);
            if(clicked!=null)mylist.Add(clicked);            
            if(mylist.Count==2){
                List<GameObject> Mylist = new List<GameObject>(mylist);
                Debug.Log((Mylist[0]).transform.position);
                line.SetPosition(0,(Mylist[0]).transform.position);
                line.SetPosition(1,(Mylist[1]).transform.position);
            }if(mylist.Count>2){
                mylist.Clear();
            }
            }
    }
}