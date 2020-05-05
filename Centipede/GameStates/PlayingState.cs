using Pacman.GameObjects;
using Pacman.GameStates;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Pacman.GameStates {
    class PlayingState : GameObjectList {
        GameObjectList ghosts;
        GameObjectList pacmanLives;
        Player thePlayer;
        Item theItem;
        //Timer theTimer;
        GameObjectList coins;
        Score theScore;
        

        
        bool Attack = false;
        int startXPosition = 70,
               startYPosition = 145,
               nGhostsPerLevel = 3,
               ghostWidth = 40,
               ghostHeight = 40;
        int iLife;



        public PlayingState() {
            
            
            this.Add(new SpriteGameObject("BackGround2.0"));


            pacmanLives = new GameObjectList();
            for (iLife = 0; iLife < 3; iLife++) {
                PacmanLife pacmanLife = new PacmanLife(new Vector2(20 + 40 * iLife, 20));
                pacmanLives.Add(pacmanLife);
            }

            ghosts = new GameObjectList();
            String[] assetNames = { "Red1", "BlueGhost", "YellowGhost" };
            
            for (int iGhostType = 0; iGhostType < assetNames.Length; iGhostType++)
                for (int IGhost = 0; IGhost < nGhostsPerLevel; IGhost++)
                    ghosts.Add(new Ghost(assetNames[iGhostType],
                        new Vector2(startXPosition + IGhost * ghostWidth, startYPosition + iGhostType * ghostHeight),
                        new Vector2((((iGhostType % 2) * 2 - 1)) * 50, 0)));
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
            //theTimer = new Timer();
            //this.Add(theTimer);
            theItem = new Item();
            this.Add(theItem);

            theScore = new Score("GameFont");
            Add(theScore);
            Reset();
        }
        public override void Reset() {
            iLife = 3;
            base.Reset();
        }
        

        public override void Update(GameTime gameTime) {

            
            int coinCount = 0;

            foreach (Ghost ghost in ghosts.Children) {

                ghost.velocity = thePlayer.position - ghost.position;
                if (ghost.velocity.Length() > 0) {
                    ghost.velocity = ghost.velocity / ghost.velocity.Length() * ghost.Speed;
                }
                bool bCollide = (ghost as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                if (bCollide) {

                    if (Attack) {
                        nGhostsPerLevel--;
                        iLife++;


                    } else {

                        iLife--;
                        pacmanLives.Children[iLife].velocity = new Vector2(0, 250.0f);
                        if (iLife <= 0) {
                            GameEnvironment.GameStateManager.SwitchTo("gameOverState");
                        }
                    }

                    if (nGhostsPerLevel <= 0) {
                        nGhostsPerLevel = nGhostsPerLevel + 2;
                    }

                }
            }
                foreach (Coin coin in coins.Children) {
                    bool bCollid = (coin as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                    if (bCollid) {
                        coinCount++;
                    }
                }

                theScore.Text = coinCount.ToString();
                bool bCollides = (theItem as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                if (bCollides) {

                Timer += gameTime.ElapsedGameTime.TotalMilliseconds; // Increment the timer by the elapsed game time.

                if (Timer >= 1000) // Check to see if one second has passed.
                {
                    Points += 10; // Increment the points by 10.
                    Timer -= 1000; // Reset the timer.
                }

                Attack = true;
                theItem.Visible = false;
                }
            base.Update(gameTime);
        }
            
        



    }
}
