// explanation video:
// https://www.youtube.com/watch?v=yxd8_BHxlmY&ab_channel=CodingWithRus

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPlaneGeneration : MonoBehaviour
{
    // defines how many quads in the X and Z dimension
    [SerializeField] private int worldX;
    [SerializeField] private int worldZ;
    
    private Mesh _mesh;
    private MeshFilter _meshFilter;
    private int[] _triangles; // 6 vertices pr. quad
    private Vector3[] _vertices; // there is 1 more vertex pr. dimension than there is a quad

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    void Start()
    {
        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;
        
        GenerateMeshPlane();
        UpdateMeshPlane();
    }

    private void GenerateMeshPlane()
    {
        _triangles = new int[worldX * worldZ * 6]; // 6 vertices pr. quad
        _vertices = new Vector3[(worldX + 1) * (worldZ + 1)];
        
         // start with Z axis to have frontfacing quads
         for (int i = 0, z = 0; z <= worldZ; z++)
         { 
             for (int x = 0; x <= worldX; x++)
             {
                 _vertices[i] = new Vector3(x, 0, z);
                 i++;
             }
         }

         int tris = 0;
         int verts = 0;
         
         for (int z = 0; z < worldZ; z++)
         {
             for (int x = 0; x < worldX; x++)
             {
                 _triangles[tris + 0] = verts + 0;
                 _triangles[tris + 1] = verts + worldZ + 1; // moving up a row, instead of continue
                 _triangles[tris + 2] = verts + 1;

                 _triangles[tris + 3] = verts + 1;
                 _triangles[tris + 4] = verts + worldZ + 1;
                 _triangles[tris + 5] = verts + worldZ + 2;

                 verts++;
                 tris += 6;
             }

             verts++;
         }
    }

    private void UpdateMeshPlane()
    {
        _mesh.Clear();
        _mesh.vertices = _vertices; // assign vertices before triangles
        _mesh.triangles = _triangles;

        _mesh.RecalculateNormals();
    }
}
