using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman {
	public class Ghost : SpriteGameObject {

		public SpriteGameObject Player;
		public int Speed = 40;
		public Ghost(String assetName, Vector2 position, Vector2 velocity) : base(assetName) {
			this.position = position;
			this.velocity = velocity;
		}



		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			


			position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X);
			position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y);
		}

		internal bool Overlaps(Player thePlayer) {
			return true;
			
		}
	}

}