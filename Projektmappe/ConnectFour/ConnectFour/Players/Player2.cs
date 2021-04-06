/**
 * 
 * Author:              Marcel Leenings
 * Last Modification:   02/2013
 * 
 * Description:
 * Player2 (Human or Computer)
 * 
 */

using System.Drawing;

namespace ConnectFour.Players
{
    class Player2 : Player
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        public Player2(string name) :
            base(Color.Blue, name)
        {
        }
    }
}
