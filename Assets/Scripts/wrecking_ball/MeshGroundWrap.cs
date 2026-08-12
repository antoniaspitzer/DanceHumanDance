using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGroundWrap : MonoBehaviour
{    
    //Optional einfach Mathf.Infinity benutzen statt dem
    [SerializeField] private float raycastHeight = 10f;
    //das kennst schon
    [SerializeField] private LayerMask groundMask;
    
    //deine Shadow Plane die du als Schatten haben möchtest
    private Mesh mesh;
    private Vector3[] originalVertices;
    private Vector3[] modifiedVertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
        modifiedVertices = new Vector3[originalVertices.Length];

        WrapMeshToGround();
    }

    void Update() {
        WrapMeshToGround();
    }
    
    private void WrapMeshToGround()
    {    
        //Durch alle Vertices durch iterieren
        for (int i = 0; i < originalVertices.Length; i++)
        {
            //position des Vertex in der Welt holen
            Vector3 worldVertex = transform.TransformPoint(originalVertices[i]);
            //Position des Rays nach oben schieben damit er wirklich alles erwischt
            Vector3 rayOrigin = worldVertex + Vector3.up * raycastHeight;
            
            //Raycast nach unten machen
            if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, raycastHeight * 2, groundMask))
            {
                //Vertex üpsotopm auf den Boden setzen mit 0.1f Offset, kann noch angepasst werden
                Vector3 hitPoint = transform.InverseTransformPoint(hit.point); // back to local space
                modifiedVertices[i] = new Vector3(originalVertices[i].x, hitPoint.y+0.01f, originalVertices[i].z);
            }
            else
            {
                // fallback: keep original y
                modifiedVertices[i] = originalVertices[i];
            }
        }

        mesh.vertices = modifiedVertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}