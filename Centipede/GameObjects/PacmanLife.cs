using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameObjects {
    class PacmanLife : TextGameObject {
        public int lives;
        
        public int Lives {
            get { return lives; }
            set {
                lives = value;
                Text = "lives:  " + lives.ToString();
                
            }
        }

        public PacmanLife(string assetName) : base(assetName) {
            spriteFont = GameEnvironment.AssetManager.Content.Load<SpriteFont>(assetName);
            color = Color.White;
            Lives = 3;
            
        }
    }
}
