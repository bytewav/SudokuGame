namespace SudokuGame
{
	using ExaGames.SudokuGenerator;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class BoardRenderer : MonoBehaviour 
	{
		public static BoardRenderer Instance;
		public SudokuBoard SudokuBoard;
		public int[,] board;

		public float Spacing = 1;

		public int Selected = 1;
		public DampedFloat[] Selecteds;

		public float SelectedOffSet;

		[Header("Multi meshFilter/Mesh renderer")]
		public Mesh[] Meshes;
		public Material[] Materials;

		void Awake()
		{
			Instance = this;
		}
		void Start () 
		{
			SudokuBoard = new SudokuBoard ();
			board = SudokuBoard.GetPuzzle ();

			Selecteds = new DampedFloat[10];
			for(int i = 0 ; i < Selecteds.Length;i++) 
			{
				Selecteds[i].Damping = 0.5f;
			}			
		}

		void Update () 
		{
			for(int i = 0 ; i < Selecteds.Length;i++) 
			{
				Selecteds[i].ApplyDamping ();
			}		

			for(int x = 0;x < 9;x++)
			{
				for (int y = 0; y < 9; y++) 
				{
					int boardNum = board [x, y];

					Vector3 p = new Vector3 (x,y,0);

					p.z = SelectedOffSet * Selecteds[boardNum].Value;

					Matrix4x4 matrice = Matrix4x4.TRS(p,Quaternion.identity,Vector3.one * Spacing);
					
					Mesh mesh = Meshes[boardNum];
					Material mat = Materials[boardNum];

					Graphics.DrawMesh(mesh,matrice,mat,0);
				}
			}

			SelectNumber (Selected);
		}

		public void SelectNumber(int number)
		{
			for(int i = 0 ; i < Selecteds.Length;i++) 
			{
				Selecteds[i].Target = (i == number) ? 1 : 0;
			}	
		}
	}
}