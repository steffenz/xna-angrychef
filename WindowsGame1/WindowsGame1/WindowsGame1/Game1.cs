using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
      
        //Lager teksturer av grafikken.
        Texture2D blackTile; //Svart brikke - solid ground
        Texture2D redTile; //Rød brikke - hvis du går i denne dør du.
        Texture2D yellowTile; //Gul brikke - level ferdig
        Texture2D tileChar; //Karakteren min.
      
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            //Setter høyde og bredde.
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            player = new Player(new Vector2(32, 544));

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Levels.Initialize();
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //laster inn 2dgrafikk
            blackTile = Content.Load<Texture2D>("blackTile");
            redTile = Content.Load<Texture2D>("redTile");
            yellowTile = Content.Load<Texture2D>("yellowTile");
            player.LoadContent(Content.Load<Texture2D>("tileChar"));


            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            player.Update(gameTime);
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();
            for (int i = 0; i < Levels.level0.GetLength(0); i++)
                for (int j = 0; j < Levels.level0.GetLength(1); j++)
                {
                    Vector2 titlePos = new Vector2(j * 32, i * 32);
                    Vector2 playerPos = player.ScreenPosition - player.MapPosition;

                    titlePos += playerPos;

                    if (Levels.level0[i, j] == 1)
                        spriteBatch.Draw(blackTile, titlePos, Color.White);
                    if (Levels.level0[i, j] == 2)
                        spriteBatch.Draw(redTile, titlePos, Color.White);
                    if (Levels.level0[i, j] == 3)
                        spriteBatch.Draw(yellowTile, titlePos, Color.White);
                }
            player.Draw(spriteBatch);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
