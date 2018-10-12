using System;
using System.Threading;
using System.Windows.Forms;

namespace HackRR2
{
    public partial class MainForm : Form
    {
        private GameState originalState;

        private GameState hackState;

        private bool backgroundRunning;

        private readonly Thread backgroundThread;

        private MemoryAccess memoryAccess;

        private bool running = true;

        public MainForm()
        {
            InitializeComponent();

            originalState = new GameState();
            hackState = CreateHackState();
            backgroundThread = new Thread(BackgroundAction);
            backgroundRunning = false;
            backgroundThread.Start();
        }

        private GameState CreateHackState()
        {
            var gameState = new GameState();
            gameState.ToxicSlowDuration = 120f;
            return gameState;
        }

        private void HackButtonClick(object sender, EventArgs e)
        {
            if (HackButton.Text == "Hack")
            {
                CreateMemoryAccess();
                ReadGameState();
            }

            var gameState = HackButton.Text == "Hack" ? hackState : originalState;
            WriteGameState(gameState);

            backgroundRunning = HackButton.Text == "Hack";
            HackButton.Text = HackButton.Text == "Hack" ? "Stop" : "Hack";
        }

        private void CreateMemoryAccess()
        {
            if (memoryAccess != null)
            {
                memoryAccess.Dispose();
            }

            memoryAccess = new MemoryAccess();
        }

        private void ReadGameState()
        {
            originalState = new GameState();
            originalState.ToxicSlowDuration = memoryAccess.ReadFloat(GameOffsets.ToxicSlowDuration);
        }

        private void WriteGameState(GameState gameState)
        {
            memoryAccess.WriteFloat(GameOffsets.ToxicSlowDuration, gameState.ToxicSlowDuration);
        }

        private void BackgroundAction()
        {
            while (running)
            {
                if (!backgroundRunning || !HackSpeedOption.Checked)
                {
                    Thread.Sleep(500);
                    continue;
                }

                memoryAccess.HackArmy((float)AttackRangeNumber.Value, (float)AttackRateNumber.Value, (float)MoveSpeedNumber.Value);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }
    }
}
