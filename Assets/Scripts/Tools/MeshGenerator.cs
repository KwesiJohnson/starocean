using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;
    public float meshHeight = 3f;

    private float perlinNoiseFactor = .3f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;        

        DrawVertices();
        UpdateMesh();
    }

    void DrawVertices()
    {
        //Set up a grid of vertices of length (xSize + 1) and width (zSize + 1)
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; ++z)
        {
            for (int x = 0; x <= xSize; ++x)
            {
                float y = Mathf.PerlinNoise(x * perlinNoiseFactor, z * perlinNoiseFactor) * meshHeight;
                vertices[i] = new Vector3(x, y, z);
                ++i;
            }
        }

        //Calculate triangle vertices
        triangles = new int[xSize * zSize * 6];

        for (int v = 0, i = 0, z = 0; z < zSize; ++z)
        {
            for (int x = 0; x < xSize; ++x)
            {
                //Draw lower triangle
                triangles[i++] = v;

                triangles[i++] = v + xSize + 1;

                triangles[i++] = v + 1;

                //Draw upper triangle
                triangles[i++] = v + 1;

                triangles[i++] = v + xSize + 1;

                triangles[i++] = v + xSize + 2;
                ++v;
            }
            ++v;
        }
    }

    void UpdateMesh()
    {
        //Clear all vertices and triangles
        mesh.Clear();

        //Draw the new vertices and triangles
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
