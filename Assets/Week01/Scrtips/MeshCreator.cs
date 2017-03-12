using UnityEngine;
using System.Collections;

public class MeshCreator : MonoBehaviour
{
  public MeshFilter meshFilter;
  public MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  [ContextMenu("Create Triangle")]
  void CreateTriangle()
  {
    meshFilter.mesh = CreatMeshTriangle(1,1);
  }
	[ContextMenu("Create Triangle with Color")]
	void CreateTriangleColors()
	{
		meshFilter.mesh = CreatMeshTriangleWithColor();
	}

	[ContextMenu("Create Triangle with UV")]
	void CreateTriangleUVs()
	{
		meshFilter.mesh = CreateMeshTriangleWithUV();
	}
	[ContextMenu("Create Quad")]
	void CreateQuad()
	{
		meshFilter.mesh = CreateQuad(2, 3);
	}
  Mesh CreatMeshTriangle(int width, int height)
  {
    Mesh m = new Mesh();
    m.name = "Mesh Name";
    // https://docs.unity3d.com/ScriptReference/Mesh-vertices.html
    // http://www.rtrclass.type.pl/wp-content/uploads/2014/06/GL-Primitives.jpg
    m.vertices = new Vector3[] {
         new Vector3(-width, -height, 0.01f),
         new Vector3(width, -height, 0.01f),
         new Vector3(width, height, 0.01f)
     };
    m.triangles = new int[] { 0, 2, 1 };
    m.RecalculateNormals();
    return m;
  }

	Mesh CreatMeshTriangleWithColor()
  {
	  var mesh = CreatMeshTriangle(2, 2);
		mesh.colors  = new Color[]
		{
				Color.red,
				Color.green,
				Color.blue,
		};
	  return mesh;
  }

	Mesh CreateMeshTriangleWithUV()
	{
		var mesh = CreatMeshTriangleWithColor();
		mesh.uv = new Vector2[]
		{
				new Vector2 (0, 0),
				new Vector2 (1, 0),
				new Vector2 (1, 1),
		};
		mesh.RecalculateNormals();
		return mesh;
	}

	Mesh CreateQuad(int width, int height)
	{
		 Mesh m = new Mesh();
		 m.name = "ScriptedMesh";
		 m.vertices = new Vector3[] {
					 new Vector3(-width, -height, 0.01f),
					 new Vector3(width, -height, 0.01f),
					 new Vector3(width, height, 0.01f),
					 new Vector3(-width, height, 0.01f)
			 };
		 m.uv = new Vector2[] {
					 new Vector2 (0, 0),
					 new Vector2 (1, 0),
					 new Vector2 (1, 1),
					 new Vector2 (0, 1)
			 };
		 m.triangles = new int[] { 0, 2, 1, 0, 3, 2 };
		 m.RecalculateNormals();
		return m;
   }
}
