﻿using System;
using System.Windows.Forms;

namespace HackRR2
{
    public partial class MainForm : Form
    {
        private GameState originalState;

        private GameState hackState;

        public MainForm()
        {
            InitializeComponent();

            originalState = new GameState();
            hackState = CreateHackState();
        }

        private GameState CreateHackState()
        {
            var gameState = new GameState();
            gameState.ToxicSlowDuration = 120f;           
            return gameState;
        }

        private void RecordButtonClick(object sender, EventArgs e)
        {
            originalState = ReadGameState();

            HackButton.Enabled = true;
        }



        private void HackButtonClick(object sender, EventArgs e)
        {
            if (HackButton.Text == "Hack")
            {
                var confirmResult = MessageBox.Show("Did you press button 'Save Original State'?",
                                     "REMEMBER TO SAVE ORIGINAL STATE BEFORE HACKING!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }
            }


            var gameState = HackButton.Text == "Hack" ? hackState : originalState;

            WriteGameState(gameState);

            HackButton.Text = HackButton.Text == "Hack" ? "Stop" : "Hack";
        }

        private GameState ReadGameState()
        {
            var gameState = new GameState();
            using (var memoryAccess = new MemoryAccess())
            {
                gameState.ToxicSlowDuration = memoryAccess.ReadFloat(GameOffsets.ToxicSlowDuration);
            }

            return gameState;
        }

        private static void WriteGameState(GameState gameState)
        {
            using (var memoryAccess = new MemoryAccess())
            {
                memoryAccess.WriteFloat(GameOffsets.ToxicSlowDuration, gameState.ToxicSlowDuration);
            }
        }
    }
}
