using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace FINAL_PROJECT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMainPage : ContentPage
    {
        private int[,] board;
        private ObservableCollection<string> trialResults;

        private int[] moveOffsetsRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
        private int[] moveOffsetsCol = { -1, 1, -2, 2, -2, 2, -1, 1 };

        private int  maxRow, maxCol;


        public NewMainPage(int rows, int cols, int startRow, int startCol, int numTrials)
        {

            InitializeComponent();
            trialResults = new ObservableCollection<string>();
            TrialResultsList.ItemsSource = trialResults;
            maxRow = rows;
            maxCol = cols;


            Random random = new Random();


            for (int i = 0; i < numTrials; i++)
            {
                int currentRow = startRow;
                int currentCol = startCol;
                int moveCount = 1;
                int[,] board = new int[rows, cols];
                board[currentRow, currentCol] = moveCount;

                CreateBoard(rows, cols, board); // Create the chessboard for the first trial

                while (moveCount < rows * cols)
                {
                    List<int> validMoveIndices = new List<int>();

                    for (int j = 0; j < 8; j++)
                    {
                        int newRow = currentRow + moveOffsetsRow[j];
                        int newCol = currentCol + moveOffsetsCol[j];

                        if (IsValidMove(newRow, newCol, rows, cols) && board[newRow, newCol] == 0)
                        {
                            validMoveIndices.Add(j);
                        }
                    }

                    if (validMoveIndices.Count > 0)
                    {
                        Shuffle(random, validMoveIndices);
                        int randomIndex = validMoveIndices[0];
                        currentRow += moveOffsetsRow[randomIndex];
                        currentCol += moveOffsetsCol[randomIndex];
                        moveCount++;
                        board[currentRow, currentCol] = moveCount;

                        // Update the chessboard for each move
                        CreateBoard(rows, cols, board);
                    }
                    else
                    {
                        break;
                    }
                }

                int successfulMoves = CountSuccessfulMoves(board);
                trialResults.Add($"Trial {i + 1}: The knight was able to successfully touch {successfulMoves} squares.");
            }
        }

        private bool IsValidMove(int row, int col, int maxRow, int maxCol)
        {
            return row >= 0 && row < maxRow && col >= 0 && col < maxCol;
        }

        private int CountSuccessfulMoves(int[,] board)
        {
            int count = 0;
            foreach (var move in board)
            {
                if (move > 0)
                {
                    count++;
                }
            }
            return count;
        }

        private void Shuffle(Random random, List<int> list)
        {
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        public void CreateBoard(int rows, int cols, int[,] knightTourBoard)
        {
            ChessBoardGrid.RowDefinitions.Clear();
            ChessBoardGrid.ColumnDefinitions.Clear();
            ChessBoardGrid.Children.Clear();

            for (int i = 0; i < rows; i++)
                ChessBoardGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            for (int j = 0; j < cols; j++)
                ChessBoardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var cellLayout = new Grid();
                    int knightMoveNumber = knightTourBoard[i, j];


                    // Create a BoxView for the border outline
                    var outline = new BoxView
                    {
                        BackgroundColor = Color.Black, // Adjust outline color
                        WidthRequest = 2, // Adjust outline width
                        HeightRequest = 2,
                    };

                    // Create a BoxView for the square background
                    var squareBackground = new BoxView
                    {
                        BackgroundColor = (i + j) % 2 == 0 ? Color.White : Color.Black,
                    };

                    // Create a Label for knight moves
                    var cellLabel = new Label
                    {
                        Text = knightMoveNumber > 0 ? knightMoveNumber.ToString() : "0",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = (i + j) % 2 == 0 ? Color.White : Color.Black,
                        TextColor = (i + j) % 2 == 0 ? Color.Black : Color.White
                    };

                    // Add BoxView for the border outline
                    cellLayout.Children.Add(outline);

                    // Add BoxView for the square background
                    cellLayout.Children.Add(squareBackground);

                    // Add Label for knight moves
                    cellLayout.Children.Add(cellLabel);

                    ChessBoardGrid.Children.Add(cellLayout, j, i);
                }
            }
        }

    }
}


