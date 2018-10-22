using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSphere : MonoBehaviour {

    public class MyRay
    {
        public float length = 2.0f;
        public Vector3 direction = Vector3.forward;
    }

    public float distance = 10.0f;
    public LayerMask mask;
    Camera tank_cam;
    MyRay[] rays;
    public LayerMask raycast_mask;


    // Use this for initialization
    void Start () {
        tank_cam = GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, mask);
        foreach (Collider col in colliders)
        {
            GameObject go = col.gameObject;
            Plane[] planes;
            planes = GeometryUtility.CalculateFrustumPlanes(tank_cam);
            if (go == gameObject)
            {
                continue;
            }

            if (GeometryUtility.TestPlanesAABB(planes, col.bounds))
            {
                RaycastHit raycasthit;
                if (Physics.Raycast(transform.position, go.transform.position))

                    
                    //if (raycasthit.rigidbody.gameObject.ToString() == "Player")
                    //{

                    //}
                        

                   Debug.Log(col.name.ToString());
     
               
            }
                

        }
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance);
    }

}
