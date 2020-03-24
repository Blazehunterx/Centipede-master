using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Centipede.GameObjects {
    class Player : SpriteGameObject {

        public Player() : base("spr_player") {
            Mouse.SetPosition(235, 500);
            Origin = new Vector2(Width / 2, Height / 2);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            
        }
    }
}
