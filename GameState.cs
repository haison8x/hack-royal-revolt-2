namespace HackRR2
{
    public class GameState
    {
        public GameState()
        {
            ArcherDamage = new float[Level.ArcherLevelCount];
            StunDuration = new float[Level.StunLevelCount];
            ToxicSlowDuration = 0;
        }

        public float[] ArcherDamage { get; set; }

        public float[] StunDuration { get; set; }

        public float ToxicSlowDuration { get; set; }
    }
}
