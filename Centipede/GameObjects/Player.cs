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
	public class Player : SpriteGameObject {

		int direction = 5;
		static SpriteSheet[] pacmanDirection = {new SpriteSheet ("PacmanDown1"),
												new SpriteSheet ("PacmanLeft1"),
												new SpriteSheet ("PacmanUp1"),
												new SpriteSheet ("Pacman2")}; 
		public Player() : base("") {
			position.X = GameEnvironment.Screen.X / 2;
			position.Y = GameEnvironment.Screen.Y / 2;
			sprite = pacmanDirection[3];
		}

		

		public override void HandleInput(InputHelper inputHelper) {
			base.HandleInput(inputHelper);

			if (inputHelper.IsKeyDown(Keys.Up)) {
				position.Y -= direction;
					sprite = pacmanDirection[2]; }

			if (inputHelper.IsKeyDown(Keys.Down)) {
				position.Y += direction;
				sprite = pacmanDirection[0];
			}
			
			if (inputHelper.IsKeyDown(Keys.Left)) {
				position.X -= direction;
				sprite = pacmanDirection[1];
			}
			
			if (inputHelper.IsKeyDown(Keys.Right)) {
				position.X += direction;
				sprite = pacmanDirection[3];
			}
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			if ((position.X > GameEnvironment.Screen.X  || (position.X < 0))) {
				position.X -= velocity.X;
			}
			if ((position.Y > GameEnvironment.Screen.Y  || (position.Y < 0))) {
				position.Y -= velocity.Y;
			}
		}
	}
}
