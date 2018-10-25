using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

public class MyData 
{
    public GameObject go;
    public Vector3 position;
    public float time = Time.time;
    public bool isDetected;
}

public class AIMemory : MonoBehaviour {
    
    public GameObject Cube;
	public Text Output;
    MyData data_base;
    public Dictionary<string, MyData> knowledge_base = new Dictionary<string, MyData>();
    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value


    // TODO 3: Capture perception events and add an entry if the player is detected
    // if the player stop from being seen, the entry should be "in the past memory"

    // Use this for initialization
    void Start () {




        
    }

	// Update is called once per frame
	void Update () 
	{
		// TODO 4: Add text output to the bottom-left panel with the information
		// of the elements in the Knowledge base

		Output.text = "test";
	}
    void PerceptionEvent(PerceptionEvent p_event)
    {
        MyData some_data = new MyData();
        some_data.go = p_event.go;
        some_data.position = p_event.go.transform.position;
        some_data.time = Time.time;
        if (p_event.type == global::PerceptionEvent.types.LOST)
        {
            some_data.isDetected = false;
            if (knowledge_base.ContainsKey("hola"))
            {
                knowledge_base.Remove("hola");
                Debug.Log("Removed Hola");
            }                           
        }
        else
        {
            if (!knowledge_base.ContainsKey("hola"))
            {
                knowledge_base.Add("hola", some_data);
                Debug.Log("Added Hola");
            }

            some_data.isDetected = true;
        }
            


        
    }
}
