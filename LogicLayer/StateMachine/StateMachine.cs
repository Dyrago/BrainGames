using BrainGames.BLL;

namespace BrainGames.BLL
{
    public class StateMachine
    {
        public State CurrentState { get; set; } = State.Initial;
        public bool GameOver { get; set; } = false;
        private Menu _menu = new Menu();
        private FastNumbers _fastNumbers = new FastNumbers();

        public void RunApp()
        {
            while (GameOver != true)
            {
                switch (CurrentState)
                {
                    case State.Initial:
                        CurrentState = State.Menu;
                        break;
                    case State.Menu:
                        _menu.DisplayMainMenu();
                        CurrentState = _menu.CurrentState;
                        break;
                    case State.Game:                  
                        switch (_menu.GameModeID)
                        {
                            case 1:
                               _fastNumbers.RunGame();
                               break;
                        }
                        break;
                    case State.Summary:
                        break;
                    default:
                        Console.Clear();
                        this.RunApp();
                        break;
                }
            }

        }
    }
}
