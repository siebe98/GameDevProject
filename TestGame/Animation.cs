using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame CurrentFrame { get; set; }
        public int AantalBewegingenPerSeconden { get; set; }
        private int counter = 0;
        private double x = 0;
        public double offset { get; set; }
        private int _totalWidth = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            AantalBewegingenPerSeconden = 1;
        }

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame newFrame = new AnimationFrame()
            {
                SourceRectangle = rectangle,
                //Duration = duration
            };
            frames.Add(newFrame);
            CurrentFrame = frames[0];
            offset = CurrentFrame.SourceRectangle.Width;
            foreach (AnimationFrame f in frames)
            {
                _totalWidth += f.SourceRectangle.Width;
            }
        }
        
        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);
            x += temp;
            if (x>= CurrentFrame.SourceRectangle.Width / AantalBewegingenPerSeconden)
            {
                Console.WriteLine(x);
                x = 0;
                counter++;
                if (counter >= frames.Count)
                {
                    counter = 0;
                }
                CurrentFrame = frames[counter];
                Debug.WriteLine(counter);
                offset += CurrentFrame.SourceRectangle.Width;
            }
            if (offset>= _totalWidth)
            {
                offset = 0;
            }
        }
    }
}
    