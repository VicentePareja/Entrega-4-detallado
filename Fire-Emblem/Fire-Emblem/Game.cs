using Fire_Emblem_View;

namespace Fire_Emblem
{
    public class Game
    {
        private readonly string _teamsFolder;
        private readonly SetUpInterface _setUpInterface;
        private readonly SetUpController _setUpController;
        private readonly BattleInterface _battleInterface;
        private readonly BattleController _battleController;
        private readonly Player _player1;
        private readonly Player _player2;
        private SetUpLogic _logic;
        private Battle _battle;
        
        public Game(View view, string teamsFolder)
        {
            _setUpController = new SetUpController(view);
            _setUpInterface = new SetUpInterface(view);
            _battleController = new BattleController(view);
            _battleInterface = new BattleInterface(view);
            _teamsFolder = teamsFolder;
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            _logic = new SetUpLogic(_teamsFolder, _setUpInterface, _setUpController, _player1, _player2);
            _battle = new Battle(_player1, _player2, _battleInterface, _battleController);
        }

        public void Play()
        {
           
            try
            {
                _logic.LoadTeams(_player1, _player2);
                _battle.Start();
            }
            catch (Exception e)
            {
                _setUpInterface.ShowError(e.Message);
            }
        }

    }
}