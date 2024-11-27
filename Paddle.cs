using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D11;

namespace ping_pong_spel
{
    public class Pallde
    {
       private Texture2D texture;
       private Rectangle rectangle;

       private int speed = 1;
       private Keys up;
       private Keys down;
       

       public Paddle(Texture2D t);
            Texture = t;


        public void update(){
            KeyboardState kState= Keyboard.GetState();
            if(kState.IsKeyDown(up)){
                rectangle.Y -= speed;
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.HotPink);
    }
}