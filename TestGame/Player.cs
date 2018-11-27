using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class Player
    {
        bool WalkLeft= false;
        bool WalkRight = false;
        public Vector2 Positie { get; set; }

        private Texture2D Texture { get; set; }
       // private Rectangle _ShowRect;

        private Animation _animationRight;
        private Animation _animationLeft;
        private Animation _idleLeft;
        private Animation _idleRight;
     
        public Vector2 VelocityX = new Vector2(2, 0);

        public Controls _controls { get; set; }
        
        
        public Player(Texture2D texture, Vector2 _positie)
        {
            Texture = texture;
            Positie = _positie;
            //_ShowRect = new Rectangle(0, 0, 21, 33);
            _controls = new BedieningPijltjes();

            _animationRight = new Animation();
            _animationLeft = new Animation();
            _idleLeft = new Animation();
            _idleRight = new Animation();

            _animationRight.AddFrame(new Rectangle(624, 0,21,33));
            _animationRight.AddFrame(new Rectangle(645,0,21,33));
            _animationRight.AddFrame(new Rectangle(666,0,21,33));
            _animationRight.AddFrame(new Rectangle(687,0,21,33));
            _animationRight.AddFrame(new Rectangle(708,0,21,33));
            _animationRight.AddFrame(new Rectangle(729,0,21,33));
            _animationRight.AddFrame(new Rectangle(750,0,21,33));
            _animationRight.AddFrame(new Rectangle(771, 0, 21, 33));
            _animationRight.AantalBewegingenPerSeconden = 5;

            _animationLeft.AddFrame(new Rectangle(456, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(477, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(498, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(519, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(540, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(561, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(582, 0, 21, 33));
            _animationLeft.AddFrame(new Rectangle(603, 0, 21, 33));
            _animationLeft.AantalBewegingenPerSeconden = 5;

            _idleRight.AddFrame(new Rectangle(0, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(19, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(38, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(57, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(76, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(95, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(114, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(133, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(152, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(171, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(190, 0, 19, 34));
            _idleRight.AddFrame(new Rectangle(209, 0, 19, 34));
            _idleRight.AantalBewegingenPerSeconden = 5;

            _idleLeft.AddFrame(new Rectangle(228, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(247, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(266, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(285, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(304, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(323, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(342, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(361, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(380, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(399, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(418, 0, 19, 34));
            _idleLeft.AddFrame(new Rectangle(437, 0, 19, 34));
            _idleLeft.AantalBewegingenPerSeconden = 5;


        }

        public void Update(GameTime gameTime)
        {
            _controls.Update();



            if (_controls.left)
            {
                Positie -= VelocityX;
                _animationLeft.Update(gameTime);
                WalkLeft = true;
                WalkRight = false;
            }
            if (_controls.right)
            {
                Positie += VelocityX;
                _animationRight.Update(gameTime);
                WalkLeft = false;
                WalkRight = true;
            }
            if (!_controls.left && !_controls.right)
            {
                if (WalkLeft)
                {
                    _idleLeft.Update(gameTime);
                }
                else
                {
                    _idleRight.Update(gameTime);
                }
            }
        }   

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_controls.right)
            {
                spriteBatch.Draw(Texture, Positie, _animationRight.CurrentFrame.SourceRectangle, Color.Wheat);
            }
            else if (_controls.left)
            {
                spriteBatch.Draw(Texture, Positie, _animationLeft.CurrentFrame.SourceRectangle, Color.Wheat);
            }
            else
            {
                if (WalkRight)
                {
                    spriteBatch.Draw(Texture, Positie, _idleRight.CurrentFrame.SourceRectangle, Color.Wheat);
                }
                else
                {
                    spriteBatch.Draw(Texture, Positie, _idleLeft.CurrentFrame.SourceRectangle, Color.Wheat);
                }
            }
        }
    }
}

