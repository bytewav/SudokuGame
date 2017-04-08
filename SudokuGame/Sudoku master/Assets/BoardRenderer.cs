namespace SudokuGame
{
	using ExaGames.SudokuGenerator;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class BoardRenderer : MonoBehaviour 
	{
		public SudokuBoard SudokuBoard;
		int[,] board;

		[Header("Multi meshFilter/Mesh renderer")]
		public Mesh[] Meshes;
		public Material[] Materials;

		void Start () 
		{
			SudokuBoard = new SudokuBoard ();
			board = SudokuBoard.GetPuzzle ();
		}

		void Update () 
		{
			for(int x = 0;x < 9;x++)
			{
				for (int y = 0; y < 9; y++) 
				{
					Vector3 p = new Vector3 (x,y,0);
					Matrix4x4 matrice = Matrix4x4.TRS(p,Quaternion.identity,Vector3.one);
					int boardNum = board [x, y];
					Mesh mesh = Meshes[boardNum];
					Material mat = Materials[boardNum];

					Graphics.DrawMesh(mesh,matrice,mat,0);
				}
			}

		}
	}
}