
using System.Windows.Forms;
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
   
   Paddle paddleleft;
   Paddle paddleright;

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
        paddleleft = new Paddle(pixel,new Rectangle(10,200,20,100),Keys.W, Keys.S);
        paddleright = new Paddle(pixel,new Rectangle(770,200,20,100),Keys.Up, Keys.Down);
    }

    protected override void Update(GameTime gameTime)
    {
      paddleleft.update();
      paddleright.update();

        ball.Update() ;
        if(paddleleft.Rectangle.Intersects(ball.Rectangle) ||
        paddleright.Rectangle.Intersects(ball.Rectangle)){
                ball.Bounce();


        }
        if(ball.Rectangle.X <=0){
            ball.Reset();
            scorerightplayer++;
        }  

        if(ball.Rectangle.X >=800){
            ball.Reset();
            scoreleftplayer++;
        }  

              // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)

    {
        
        GraphicsDevice.Clear(Color.Red);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();


        _spriteBatch.DrawString(fontscore, scoreleftplayer.ToString(), new Vector2(10,10), Color.Red);
        _spriteBatch.DrawString(fontscore, scorerightplayer .ToString(), new Vector2(730,10), Color.Red);



       paddleleft.Draw(_spriteBatch);
       paddleright.Draw(_spriteBatch);
       ball.Draw(_spriteBatch);
         _spriteBatch.End();


        base.Draw(gameTime);
    }
}
