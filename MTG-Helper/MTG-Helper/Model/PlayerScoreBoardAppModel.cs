using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MTG_Helper.Model
{
    public class PlayerScoreboardAppModel
    {
        private Scoreboard view;

        public PlayerScoreboardAppModel(Scoreboard view)
        {
            this.view = view;
        }

        public Canvas addAPlayerScoreboard()
        {
            return (new PlayerScoreboardPostix(this).getShape());
        }

        public void removeSpecificPlayerScoreBoard(Canvas canvas)
        {
            this.view.removeSpecificPlayerScoreBoard(canvas);
        }

        public PlayerScoreboard createNewScoreBoard()
        {
            return new PlayerScoreboard();
        }
    }
}
