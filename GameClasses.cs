using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Jam_Game
{

    // This is the class for player
    public class Player : Entity
    {
        public Player()
        {
            Transform transform = new Transform();
            this.AddComponent(transform);
            AnimatedSprite sprite = new AnimatedSprite("Sprites/testSheetFuck", 10, 8);
            this.AddComponent(sprite);
            

        }

        public void Move(Vector2 move)
        {
            this.GetComponent<Transform>().position += move;
        }
    }


        

}
