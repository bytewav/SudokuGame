using ExaGames.Common;

namespace ExaGames.SudokuGenerator 
{
	
	public class SudokuBoard 
	{
		private const int SIZE = 9;
		public int[,] Board { get; private set; }
	
		public SudokuBoard() 
		{
			Board = new int[SIZE, SIZE];
			bool created = false;
			while(!created) 
			{
				Board = new int[SIZE, SIZE];
				created = place(1);
			}
		}
	
		public int[,] GetPuzzle() 
		{
			int[,] puzzle = new int[SIZE, SIZE];
			RandomList<int> random = initRandomList(false);
			for(int i = 0; i < SIZE; i++) 
			{
				if(random.IsEmpty()) 
					random = initRandomList(false);
				
				for(int j = 0; j < 3; j++) 
				{
					int column = random.GetRandom();
					puzzle[i, column] = Board[i, column];
				}
			}
			return puzzle;
		}
	
		private bool place(int value) 
		{
			if(value > SIZE) 
				return true;
			else 
			{
				bool placed = false;
				if(place(value, 0, initRandomList(false))) 
					placed = place(value + 1);
				
				return placed;
			}
		}
	
		private bool place(int value, int row, RandomList<int> availableColumns) 
		{
			if(row == SIZE) 
				return true;
			else 
			{
				bool placed = false;
				uint excludeFromRandom = 0;
				while(!placed && !availableColumns.IsEmpty(excludeFromRandom)) 
				{
					int column = availableColumns.GetRandom(excludeFromRandom, true);
					if(canPlace(value, row, column)) 
					{
						Board[row, column] = value;
						placed = place(value, row + 1, availableColumns);
						if(!placed) 
							Board[row, column] = 0;
					} 
					if(!placed) 
					{
						availableColumns.Append(column);
						excludeFromRandom++;	
					}
				}
				return placed;
			}
		}
	
		private bool canPlace(int value, int inRow, int inColumn) 
		{
			int quadrantVert = inRow / 3;
			int quadrantHor = inColumn / 3;

			if(Board[inRow, inColumn] > 0) 
				return false;
			
			for(int i = 3 * quadrantVert; i < inRow; i++) 
				for(int j = 3 * quadrantHor; j < 3 * (quadrantHor + 1); j++) 
					if(Board[i, j] == value) 
						return false;
			
			return true;
		}
	
		private RandomList<int> initRandomList(bool offsetByOne = true) 
		{
			int offset = offsetByOne ? 1 : 0;
			RandomList<int> randomList = new RandomList<int>();
			for(int i = offset; i < SIZE + offset; i++) 
				randomList.Append(i);
			
			return randomList;
		}
	
		public override string ToString() 
		{
			return Board.MatrixToString();
		}
	}
}