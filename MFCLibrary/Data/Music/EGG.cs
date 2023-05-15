
namespace MFCLibrary.Data.Music
{
    public static class EGG
    {
        public static void SovietUnion()
        {
            System.Media.SoundPlayer SU = new(@"EGG.wav");
            SU.Play();
            Console.Read();
        }
    }
}
