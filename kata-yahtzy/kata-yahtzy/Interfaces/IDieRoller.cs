namespace kata_yahtzy
{
    public interface IDieRoller
    {
        int[] RollDie();

        int[] RerollDie(int[] dieArray, bool[] dieIndexToRerollArray);
    }
}