using Pacman.GameObjects;
using Pacman.GameStates;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Pacman.GameStates {
    class PlayingState : GameObjectList {
        GameObjectList ghosts;
        PacmanLife thepacmanLife;
        Player thePlayer;
        Item theItem;
       
        GameObjectList coins;
        Score theScore;

        int fontSize = 20;
        
        bool Attack = false;
        static int startXPosition = GameEnvironment.Random.Next(-200,1200),
               startYPosition = GameEnvironment.Random.Next(-200, 0),
               nGhostsPerLevel = 10,
               ghostWidth = 100,
               ghostHeight = 100;
        int nGhostInLevel = nGhostsPerLevel + 2;
        float timeSinceItemPickup = 0f;
        float timeSinceHitByEnemy = 0f;
        bool hit = true;

        public PlayingState() {
  
            this.Add(new SpriteGameObject("BackGround2.0"));

            ghosts = new GameObjectList();
            wave();
            this.Add(ghosts);

            coins = new GameObjectList();
            String[] assetName = { "Dot" };
            int nCoinPerlevel = 100;
            for (int iCoinType = 0; iCoinType < assetName.Length; iCoinType++)
                for (int ICoin = 0; ICoin < nCoinPerlevel; ICoin++)
                    coins.Add(new Coin(assetName[iCoinType]));
            this.Add(coins);

            thePlayer = new Player();
            this.Add(thePlayer);

            theItem = new Item();
            this.Add(theItem);

            theScore = new Score("GameFont");
            Add(theScore);
            thepacmanLife = new PacmanLife("GameFont");
            thepacmanLife.Position = new Vector2(0, fontSize);
            Add(thepacmanLife);
            Reset();
        }
        public void wave() {
            String[] assetNames = { "Red1", "BlueGhost", "YellowGhost" };

            for (int iGhostType = 0; iGhostType < assetNames.Length; iGhostType++)
                for (int IGhost = 0; IGhost < nGhostsPerLevel; IGhost++)
                    ghosts.Add(new Ghost(assetNames[iGhostType],
                        new Vector2(startXPosition + IGhost * ghostWidth, startYPosition + iGhostType * ghostHeight),
                        new Vector2((((iGhostType % 2) * 20 - 10)) * 80, 0)));
        }
        public override void Reset() {
            thepacmanLife.lives = 3;
            wave();
        }


        public override void Update(GameTime gameTime) {

            timeSinceItemPickup += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceHitByEnemy += (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (Ghost ghost in ghosts.Children) {

                ghost.velocity = thePlayer.position - ghost.position;
                if (ghost.velocity.Length() > 0) {
                    ghost.velocity = ghost.velocity / ghost.velocity.Length() * ghost.Speed;
                }
                bool bCollide = (ghost as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                if (bCollide && hit) {

                    if (Attack) {
                        ghost.Visible = false;
                        nGhostsPerLevel--;
                        thepacmanLife.lives++;


                    } else {

                        thepacmanLife.lives--;
                        hit = false;
                        
                        if (thepacmanLife.lives == 0) {
                            GameEnvironment.GameStateManager.SwitchTo("gameOverState");
                        }
                    }
                    if (nGhostsPerLevel == 0) {
                        GameEnvironment.GameStateManager.SwitchTo("winState");
                       
                    }
                    if(hit == false) {
                        if (timeSinceHitByEnemy > 2f) {
                            hit = true;
                        }
                    }
                    

                }
            }
            foreach (Ghost ghost in ghosts.Children) {
                bool bCollides = (theItem as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                if (bCollides) {

                    if (timeSinceItemPickup > 2f) {
                        Attack = true;
                        theItem.Visible = false;
                    }
                    if (timeSinceItemPickup > 10f) {
                        Attack = false;
                        if (ghost.Visible ==false) {
                        if (timeSinceItemPickup > 10f) {
                            theItem.Visible = true;
                        }                          
                    }
                }
                foreach (Coin coin in coins.Children) {
                    bool bCollid = (coin as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                    if (bCollid) {
                        theScore.Points++;
                        coin.Visible = false;
                    }
                }
                base.Update(gameTime);
            }
        }
    }
}
