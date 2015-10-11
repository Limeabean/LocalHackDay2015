using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite menuSprite;
        Sprite creditSprite;
        Sprite gameOverSprite;
        Menu menu;
        Sprite pointerSprite;
        int menuSelection = 0;
        Sprite ballsprite, paddlesprite1, paddlesprite2, paddlesprite3, paddlesprite4;
        Ball gameball;
        Paddle paddle1, paddle2, paddle3, paddle4;
        bool running = false, gameover=false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            menuSprite = new Sprite();
            pointerSprite = new Sprite();
            creditSprite = new Sprite();
            gameOverSprite = new Sprite();

            gameball = new Ball(285, 285, 30, 30, 5, 5);
            paddle1 = new Paddle(1);
            paddle2 = new Paddle(2);
            paddle3 = new Paddle(3);
            paddle4 = new Paddle(4);
            ballsprite = new Sprite(gameball.getx(), gameball.gety());
            paddlesprite1 = new Sprite(paddle1.getX(), paddle1.getY());
            paddlesprite2 = new Sprite(paddle2.getX(), paddle2.getY());
            paddlesprite3 = new Sprite(paddle3.getX(), paddle3.getY());
            paddlesprite4 = new Sprite(paddle4.getX(), paddle4.getY());
            menu = new Menu();
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

            menuSprite.loadContent(this.Content, "menu");
            pointerSprite.loadContent(this.Content, "pointer");
            creditSprite.loadContent(this.Content, "credits");
            gameOverSprite.loadContent(this.Content, "gameover");
            ballsprite.loadContent(this.Content, "Ball");
            paddlesprite1.loadContent(this.Content, "PaddleLeft");
            paddlesprite2.loadContent(this.Content, "PaddleRight");
            paddlesprite3.loadContent(this.Content, "PaddleTop");
            paddlesprite4.loadContent(this.Content, "PaddleBot");

            // TODO: use this.Content to load your game content here
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            int new_x = Mouse.GetState().X;
            int new_y = Mouse.GetState().Y;
            KeyboardState state = Keyboard.GetState();
            bool pressed;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                pressed = true;
            }
            else
            {
                pressed = false;
            }
            menuSelection = menu.getSelection(new_x,new_y,pressed);

            pointerSprite.update(new_x, new_y);

            if (running)
            {
                gameball.move(paddle1,paddle2,paddle3,paddle4);
      
                ballsprite.update(gameball.getx(), gameball.gety());
                paddle1.move(state);
                paddle2.move(state);
                paddle3.move(state);
                paddle4.move(state);
                paddlesprite1.update(paddle1.getX(), paddle1.getY());
                paddlesprite2.update(paddle2.getX(), paddle2.getY());
                paddlesprite3.update(paddle3.getX(), paddle3.getY());
                paddlesprite4.update(paddle4.getX(), paddle4.getY());
                if (gameball.offscreen())
                {
                    gameover = true;
                    running = false;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            pointerSprite.render(spriteBatch);

            if (running)
            {
                ballsprite.render(spriteBatch);
                paddlesprite1.render(spriteBatch);
                paddlesprite2.render(spriteBatch);
                paddlesprite3.render(spriteBatch);
                paddlesprite4.render(spriteBatch);
            }
            else if (gameover)
            {
                gameOverSprite.render(spriteBatch);
            }
           else if (menuSelection == 2)
            {
                creditSprite.render(spriteBatch);
            }
            else if (menuSelection == 0)
            {
                menuSprite.render(spriteBatch);
            }
            else if (menuSelection == 1)
            {
                running = true;
            }
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
