using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MeshTopologyChanger : MonoBehaviour
{
    [SerializeField]
    MeshTopology meshTopology = MeshTopology.Triangles;

    MeshFilter meshFilter;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), meshTopology, 0);
    }

    void Update()
    {
        
    }

    void OnValidate()
    {
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), meshTopology, 0);
    }
}
