/**
 * 
 * Author:              Marcel Leenings
 * Last Modification:   02/2013
 * 
 * Description:
 * Base class with basic functionalities for the players
 * 
 */

using System.Drawing;

namespace ConnectFour.Players
{
    class Player
    {
        /* color of the tile */
        public Color? Tile { get; protected set; }

        /* name of the player */
        public string Name { get; set; }

        /* numb of won rounds */
        public int WonRounds { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="name"></param>
        public Player(Color? tile, string name)
        {
          WonRounds = 0;
          this.Tile = tile;
          this.Name = name;
        }
    }
}
