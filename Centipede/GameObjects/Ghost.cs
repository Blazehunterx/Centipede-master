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
		public int Speed = 6;
		public Ghost(String assetName, Vector2 position, Vector2 velocity) : base(assetName) {
			this.position = position;
			this.velocity = velocity;
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);
			position += velocity;
			if ((position.X > GameEnvironment.Screen.X || (position.X < 0))) {
				velocity.X = -velocity.X;
			}
			if ((position.Y > GameEnvironment.Screen.Y || (position.Y < 0))) {
				velocity.Y = -velocity.Y;
			}
			
		}
	}

}