using System;
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
            hackState = new GameState();
            hackState.ToxicSlowDuration = 300f;
            for (var i = 0; i < Level.ArcherLevelCount; i++)
            {
                hackState.ArcherDamage[i] = 100000f;
            }

            for (var i = 0; i < Level.StunLevelCount; i++)
            {
                hackState.StunDuration[i] = 300f;
            }
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

                var archerDamageAddress = memoryAccess.ReadAddress(GameOffsets.ArcherDamage);
                for (var i = 0; i < Level.ArcherLevelCount; i++)
                {
                    var address = archerDamageAddress + i * 0x190;
                    gameState.ArcherDamage[i] = memoryAccess.ReadFloat(address);
                }

                var stunDurationAddress = memoryAccess.ReadAddress(GameOffsets.StunDuration);
                for (var i = 0; i < Level.StunLevelCount; i++)
                {
                    var address = stunDurationAddress + i * 0x190;
                    gameState.StunDuration[i] = memoryAccess.ReadFloat(address);
                }
            }

            return gameState;
        }

        private static void WriteGameState(GameState gameState)
        {
            using (var memoryAccess = new MemoryAccess())
            {
                memoryAccess.WriteFloat(GameOffsets.ToxicSlowDuration, gameState.ToxicSlowDuration);
                var archerDamageAddress = memoryAccess.ReadAddress(GameOffsets.ArcherDamage);
                for (var i = 0; i < Level.ArcherLevelCount; i++)
                {
                    var address = archerDamageAddress + i * 0x190;
                    memoryAccess.WriteFloat(address, gameState.ArcherDamage[i]);
                }

                var stunDurationAddress = memoryAccess.ReadAddress(GameOffsets.StunDuration);
                for (var i = 0; i < Level.StunLevelCount; i++)
                {
                    var address = stunDurationAddress + i * 0x190;
                    memoryAccess.WriteFloat(address, gameState.StunDuration[i]);
                }
            }
        }
    }
}
