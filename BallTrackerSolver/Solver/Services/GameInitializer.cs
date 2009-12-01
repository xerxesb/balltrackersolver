using Solver.Models;

namespace Solver
{
    public class GameInitializer
    {
        private Grid _grid;

        public GameInitializer()
        {
            _grid = new Grid(4, 4);
            _grid.SetBall(1, 1);
            _grid.AddBrick(4, 4, true, Direction.Down);
        }

        public void SolveGame()
        {
            var solver = new Solver(_grid);
            solver.SolveProblem();
        }
    }
}