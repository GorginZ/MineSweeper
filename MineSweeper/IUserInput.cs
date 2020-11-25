namespace MineSweeper
{
  public interface IUserInput
  {
    void Read();
    RowColumn ParseInputToRowColumn();
  }
}