using System.Text;

namespace BrainGames.BLL
{
    public class Menu
    {
        

        private StringBuilder _menuBuilder = new StringBuilder();

        public State CurrentState { get; set; } = State.Menu;
        public int GameModeID { get; set; }

        public void DisplayMainMenu()
        {
            int _menuOption;
            _menuBuilder.Clear();

            _menuBuilder.AppendLine("1.Choose Game");
            _menuBuilder.AppendLine("2.Leader Board");
            _menuBuilder.AppendLine("3.Exit");

            Console.WriteLine(_menuBuilder.ToString());
            _menuOption = Convert.ToInt32(Console.ReadLine());

            switch (_menuOption)
            {
                case 1:
                    Console.Clear();
                    DisplayGamesMenu();
                    break;
                case 2:
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    this.DisplayMainMenu();
                    break;
            }
        }

        public void DisplayGamesMenu()
        {
            int _menuOption;

            _menuBuilder.Clear();

            _menuBuilder.AppendLine("1.Fast Numbers");
            _menuBuilder.AppendLine("2.Memory");
            _menuBuilder.AppendLine("3.Back To Main Menu");

            Console.WriteLine(_menuBuilder.ToString());
            _menuOption = Convert.ToInt32(Console.ReadLine());

            switch (_menuOption)
            {
                case 1:
                    SetGameModeID(1);
                    SetState(State.Game);
                    break;
                case 2:
                    break;
                case 3:
                    Console.Clear();
                    DisplayMainMenu();
                    break;
                default:
                    Console.Clear();
                    this.DisplayGamesMenu();
                    break;
            }
        }

        private State SetState(State state)
        {
            return CurrentState = state;
        }

        private int SetGameModeID(int id)
        { 
            return GameModeID = id;
        }
    }
}
