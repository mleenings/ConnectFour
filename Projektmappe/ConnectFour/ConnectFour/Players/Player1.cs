/**
 * 
 * Author:              Marcel Leenings
 * Version:             1.0
 * Last Modification:   02/2013
 * 
 * Description:
 * Player1 (Human)
 * 
 */

using System.Drawing;

namespace ConnectFour.Players
{
    class Player1 : Player
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        public Player1(string name) :
            base(Color.Red,name)
        {
        }
    }
}
