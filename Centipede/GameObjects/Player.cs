﻿using System;
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

		int direction = 30;
		public Player() : base("Pacman1") {
			this.Origin = this.Center;
		}

		

		public override void HandleInput(InputHelper inputHelper) {
			base.HandleInput(inputHelper);

			if (inputHelper.KeyPressed(Keys.Up)) position.Y -= direction;
			if (inputHelper.KeyPressed(Keys.Down)) position.Y += direction;
			if (inputHelper.KeyPressed(Keys.Left)) position.X -= direction;
			if (inputHelper.KeyPressed(Keys.Right)) position.X += direction;
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X);
			position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y);
		}
	}
}
