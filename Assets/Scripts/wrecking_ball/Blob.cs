using UnityEngine;

public class Blob : MonoBehaviour
{
    public GameObject shadow;
    public RaycastHit hit;
    public float offset;
    public LayerMask layerMask;

    private void FixedUpdate() 
    {
        // Ray downRay = new Ray(new Vector3(this.transform.position.x, this.transform.position.y - offset, this.transform.position.z), -Vector3.up);

RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask)) {
                    shadow.transform.position = hit.point;
        }

        // // gets the hit from the raycast and converts it unto a vector3
        // Vector3 hitPosition = hit.point;
        // //transform the shadow to the location

        // // Cast a ray straight downwards, reads back where it lands (this is optional but recommended)
        // if (Physics.Raycast(downRay, out hit))
        // {
        //     print(hit.transform);
        // }
    }








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
