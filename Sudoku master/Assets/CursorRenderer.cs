namespace SudokuGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class CursorRenderer : MonoBehaviour 
	{
		public Mesh Meshes;
		public Material Materials;

		void Start ()
		{
		}

		void Update()
		{
			Camera cam = Camera.main;

			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) 
			{
				Transform objectHit = hit.transform;


				Mesh mesh = Meshes;
				Material mat = Materials;


				int x = (int)(hit.point.x + 0.5f);
				int y = (int)(hit.point.y + 0.5f);
				float z = hit.point.z;

				//if(x > 8 || x < 0)
				int boardNum = BoardRenderer.Instance.board [x, y];

				Matrix4x4 matrice = Matrix4x4.TRS(new Vector3((float)x,(float)y,z),Quaternion.identity,Vector3.one);
				Graphics.DrawMesh(mesh,matrice,mat,0);

				if(boardNum > 0)
					BoardRenderer.Instance.SelectNumber (boardNum);
			}
			//ray.GetPoint();

			//Vector3 WmousePos = cam.ScreenToWorldPoint (Input.mousePosition);

			//ctor3 p = WmousePos;


		}
	}
}