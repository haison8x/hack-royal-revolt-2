namespace HackRR2
{
    public class GameState
    {
        public GameState()
        {
            StunDuration = new float[Level.StunLevelCount];
            ToxicSlowDuration = 0;
        }

        public float[] StunDuration { get; set; }

        public float ToxicSlowDuration { get; set; }
    }
}
