using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class Player
    {
        public Vector2 MapPosition;
        public Vector2 ScreenPosition;
        private Texture2D texture;
        private Vector2 speed;
        private KeyboardState kbState;

        //konstruktør, tar i mot player spawn point.
        public Player(Vector2 p)
        {
            MapPosition = p;
            ScreenPosition = new Vector2(400, 300);
        }

        //laster inn spiller tekstur.
        public void LoadContent(Texture2D t)
        {
            texture = t;
        }

        public void Update(GameTime gameTime)
        {
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Left))
                speed.X = -300 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kbState.IsKeyDown(Keys.Right))
                speed.X = 300 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kbState.IsKeyDown(Keys.Space))
                speed.Y = -300 *(float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                speed.X = 0;
            MapPosition += speed;
        }

        public void Draw(SpriteBatch spriteBatch) 
        { 
            spriteBatch.Draw(texture, ScreenPosition, Color.White);
        }
        

    }
}
