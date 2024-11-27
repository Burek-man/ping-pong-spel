
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ping_pong_spel;
using SharpDX.XInput;

namespace ping_pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;

    SpriteFont fontscore;
    Rectangle paddleLeft = new Rectangle(10,200,20,100);
    Rectangle paddleRight = new Rectangle(770,200,20,100);

    ball ball;


    int scoreleftplayer = 0;
    int scorerightplayer = 0;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>(assetName: "BALL");
        fontscore = Content.Load<SpriteFont>("score");

        ball = new ball(pixel);
    }

    protected override void Update(GameTime gameTime)
    {
        if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.W) && paddleLeft.Y > 0){
            paddleLeft.Y -=8;
        }

        if(kState.IsKeyDown(Keys.S) && paddleLeft.Y + paddleLeft.Height < 400){
            paddleLeft.Y +=8;
        }

        KeyboardState kstate = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.W) && paddleRight.Y > 0){
            paddleRight.Y -=8;
        }

        if(kState.IsKeyDown(Keys.S) && paddleRight.Y + paddleLeft.Height < 400){
            paddleRight.Y +=8;
        }
        ball.Update() ;

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)

    {
        
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();


        _spriteBatch.DrawString(fontscore, scoreleftplayer.ToString(), new Vector2(10,10), Color.Red);
        _spriteBatch.DrawString(fontscore, scorerightplayer .ToString(), new Vector2(730,10), Color.Red);



        _spriteBatch.Draw(pixel,paddleLeft,Color.HotPink);
        _spriteBatch.Draw(pixel,paddleRight,Color.HotPink);
        ball.Draw(_spriteBatch);
         _spriteBatch.End();


        base.Draw(gameTime);
    }
}
