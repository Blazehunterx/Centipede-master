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
			this.velocity = new Vector2(GameEnvironment.Random.Next(0,6));
		}

		internal bool Overlaps(Player thePlayer) {
			return true;
			
		}
	}

}