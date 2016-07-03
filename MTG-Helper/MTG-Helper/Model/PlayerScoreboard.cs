using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_Helper.Model
{
    public class PlayerScoreboard : INotifyPropertyChanged
    {

        public string playerName { get; set; }
        public int lifePoints { get; set; }
        public int poisonPoints { get; set; }

        public PlayerScoreboard()
        {
            this.playerName = "Foo";
            this.lifePoints = 20;
            this.poisonPoints = 0;
        }

        /// <summary>
        /// The Property Changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Handle's the propertyChanged.
        /// </summary>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Notifies the listener that property has changed.
        /// </summary>
        private void notifyPropertyChanged(String propertyName)
        {
            this.OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Returns the remaining players's life points.
        /// </summary>
        public int getLifePoints()
        {
            return this.lifePoints;
        }

        /// <summary>
        /// Add one life point to the remaining players's life points.
        /// </summary>
        public void addOneLifePoints()
        {
            this.lifePoints++;
            this.notifyPropertyChanged("lifePoints");
        }

        /// <summary>
        /// Sub one life point to the remaining players's life points.
        /// </summary>
        public void subOneLifePoints()
        {
            if (this.getLifePoints() > 0)
            {
                this.lifePoints--;
                this.notifyPropertyChanged("lifePoints");
            }
        }

        /// <summary>
        /// Add X life point to the remaining players's life points.
        /// </summary>
        private void addXLifePoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.addOneLifePoints();
            }
        }

        /// <summary>
        /// Sub X life point to the remaining players's life points.
        /// </summary>
        private void subXLifePoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.subOneLifePoints();
            }
        }

        /// <summary>
        /// Add X poison point to the remaining players's life points.
        /// </summary>
        private void addXPoisonPoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.addOnePoisonPoint();
            }
        }

        /// <summary>
        /// Sub X poison point to the remaining players's life points.
        /// </summary>
        private void subXPoisonPoints(int numberOfLifePoints)
        {
            for (int i = 0; i < numberOfLifePoints; i++)
            {
                this.subOnePoisonPoint();
            }
        }

        /// <summary>
        /// Add five life point to the remaining players's life points.
        /// </summary>
        public void addFiveLifePoints()
        {
            this.addXLifePoints(5);
            this.notifyPropertyChanged("lifePoints");
        }

        /// <summary>
        /// Sub five life point to the remaining players's life points.
        /// </summary>
        public void subFiveLifePoints()
        {
            this.subXLifePoints(5);
            this.notifyPropertyChanged("lifePoints");
        }


        /// <summary>
        /// Returns the remaining players's poison points.
        /// </summary>
        public int getPoisonPoints()
        {
            return this.poisonPoints;
        }

        /// <summary>
        /// Add one poison point to the remaining players's poison points.
        /// </summary>
        public void addOnePoisonPoint()
        {
            this.poisonPoints++;
            this.notifyPropertyChanged("poisonPoints");
        }

        /// <summary>
        /// Sub one poison point to the remaining players's poison points.
        /// </summary>
        public void subOnePoisonPoint()
        {
            if (this.getPoisonPoints() > 0)
            {
                this.poisonPoints--;
                this.notifyPropertyChanged("poisonPoints");
            }
        }

        /// <summary>
        /// Add five poison point to the remaining players's life points.
        /// </summary>
        public void addFivePoisonPoints()
        {
            this.addXPoisonPoints(5);
            this.notifyPropertyChanged("poisonPoints");
        }

        /// <summary>
        /// Sub five poison point to the remaining players's life points.
        /// </summary>
        public void subFivePoisonPoints()
        {
            this.subXPoisonPoints(5);
            this.notifyPropertyChanged("poisonPoints");
        }

        /// <summary>
        /// Returns the players's name.
        /// </summary>
        public string getPlayerName()
        {
            return this.playerName;
        }

        /// <summary>
        /// Change the players's name for another.
        /// </summary>
        public void changeName(string aName)
        {
            this.playerName = aName;
        }

        public void reset()
        {
            this.lifePoints = 20;
            this.poisonPoints = 0;
            this.notifyPropertyChanged("lifePoints");
            this.notifyPropertyChanged("poisonPoints");
        }

    }
}
