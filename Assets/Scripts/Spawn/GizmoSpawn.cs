using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoSpawn : MonoBehaviour
{
    [SerializeField]
    private float scale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.color = new Color(0, 0.5f, 1);
        Gizmos.DrawCube(Vector3.zero, new Vector3(scale,2f * scale, scale));
        Gizmos.DrawRay(Vector3.zero, Vector3.forward);
    }
}
