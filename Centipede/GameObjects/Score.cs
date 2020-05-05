using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameObjects {
    class Score : TextGameObject {
        private int points;

        public int Points {
            get { return points; }
            set {
                points = value;
                Text = points.ToString();
            }
        }

        public Score(string assetName) : base(assetName) {
            spriteFont = GameEnvironment.AssetManager.Content.Load<SpriteFont>(assetName);
            color = Color.White;
            Points = 0;
        }
    }
}
