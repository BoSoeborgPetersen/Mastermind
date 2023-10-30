using System.Windows.Input;

namespace Mastermind.ViewModel;

public class MainViewModel : BaseViewModel
{
    public GameBoardViewModel GameBoard { get; private set; }
    public ColorsViewModel Colors { get; private set; }


    //public Field FieldBeingChanged { get; private set; }

    ////public ICommand FieldSelectedCommand { get; private set; }
    //public ICommand BidConfirmedCommand { get; private set; }

    //// Should be derived.

    //public List<int> FieldNumbers { get { return Enumerable.Range(0, GameBoard.RowCount).Reverse().ToList(); } }
    //public bool IsSolved { get { return GameBoard.IsSolved; } }

    public MainViewModel()
    {
        GameBoard = new(this);
        Colors = new(this);


        //    // TODO: Temp
        //    AreColorsVisible = true;
        //    //FieldSelectedCommand = new RelayCommand<PointerRoutedEventArgs>(FieldSelected);
        //    BidConfirmedCommand = new RelayCommand<Row>(BidConfirmed);
    }

    //public void FieldSelected(Field _field)
    //{
    //    AreColorsVisible = true;
    //    OnPropertyChanged(nameof(AreColorsVisible));
    //    FieldBeingChanged = _field;
    //}

    //public void FieldColorSelected(Color _color)
    //{
    //    int value = FieldColors.IndexOf(_color);
    //    FieldBeingChanged.Value = value;
    //    FieldBeingChanged = null;
    //    AreColorsVisible = false;
    //    OnPropertyChanged(nameof(AreColorsVisible));
    //}

    //public void BidConfirmed(Row _row)
    //{
    //    tacticEngine.SolveRow(_row.GameBoard);
    //    _row.GameBoard.NextBid();
    //    _row.NPC("IsActive");
    //    GameBoard.ActiveBid?.NPC("IsActive");
    //    GameBoard.NPC("GameInProgress");
    //    GameBoard.NPC("IsSolved");
    //    GameBoard.NPC("IsFailed");
    //}
}
