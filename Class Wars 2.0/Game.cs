using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;
using Terraria;

namespace Class_Wars_2._0
{

    /*Stages:
    * -Verify Classes are selected
    * -Verify teams are within 1 player of even
    * -Teleport to chosen arena
    * -Set player's spawns to arena
    * -Countdown, with re-teleport at each step
    * -Begin game loop
    *   -Check for wins on block broken
    *   -Broadcast score to all players (on server or just in game?) every 60? seconds
    *   -Teleport players back to their spawn if outside arena?
    * -End game loop when a team wins
    * -Broadcast score (and stats?)
    * -Reset bunkers
    */

    class Game
    {
        #region Construction
        private List<PlayerInfo> Players;
        private List<int> playerIDs;
        private Arena arena;
        private bool altTeams;
        private bool won, doubledChecked, winner; //false for blue, true for red
        private int blueScore, redScore;

        public Game(List<PlayerInfo> p, Arena a, bool altT)
        {
            Players = p;
            arena = a;
            altTeams = altT;
            won = false;
            winner = false;
            CheckScore();
            StartGame();
        }
        #endregion

        #region GameInit
        private void StartGame()
        {
            if (Verification())
            {
                Countdown();
            }
        }

        private bool Verification()
        {
            bool verified = false;

            return verified;
        }

        private void TeleportPlayers()
        {
            foreach (PlayerInfo p in Players.Where(x => x.team))
                p.Teleport(arena.rSpawn);
            foreach (PlayerInfo p in Players.Where(x => !x.team))
                p.Teleport(arena.bSpawn);
        }

        private void Countdown()
        {

        }
        #endregion

        #region GameProcessing
        private void CheckWins()
        {
            CheckScore();
            if (blueScore == 0)
            {
                winner = true;
                won = true;
            }
            if (redScore == 0)
            {
                winner = false;
                won = true;
            }
        }

        private void CheckScore()
        {
            int tempBlueScore = 0, tempRedScore = 0;
            for (int i = 0; i <= arena.arenaBottomR.X - arena.arenaTopL.X; i++)
            {
                for (int j = 0; j <= arena.arenaBottomR.Y - arena.arenaTopL.Y; j++)
                {
                    int tile = Main.tile[(int)arena.arenaTopL.X + i, (int)arena.arenaTopL.Y + j].type;
                    int color;
                    if (tile == 25 || tile == 203 || tile == 117)
                    {
                        color = Main.tile[(int)arena.arenaTopL.X + i, (int)arena.arenaTopL.Y + j].wallColor();
                        if (color == Utils.bluePaintID)
                            tempBlueScore++;
                        if (color == Utils.redPaintID)
                            tempRedScore++;
                    }
                }
            }
            blueScore = tempBlueScore;
            redScore = tempRedScore;
        }

        private void BroadcastScore()
        {

        }
        #endregion

        #region GameUtils
        public bool IsPlaying(int userID)
        {
            return playerIDs.Contains(userID);
        }

        public void JoinGame(PlayerInfo p)
        {
            if (!playerIDs.Contains(p.UserID))
            {
                playerIDs.Add(p.UserID);
            }
        }

        public void Leave(int userID)
        {
            playerIDs.RemoveAll(p => p == userID);
            Players.RemoveAll(p => p.UserID == userID);
        }
#endregion
    }
}
