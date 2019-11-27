using System;

namespace kata_yahtzy
{
    public class RandomDieRoller : IDieRoller
    {

        Random RandomGenerator = new Random();

        public int[] RollDie()
        {

            var dieArray = new int[5];
            
            for (var i = 0; i < 5; i++)
            {
                dieArray[i] = RandomGenerator.Next(1, 6);
            }

            return dieArray;
        }

        public int[] RerollDie(int[] dieArray, bool[] dieIndexToRerollArray)
        {

            for (var i = 0; i < 5; i++)
            {
                if (dieIndexToRerollArray[i])
                {
                    dieArray[i] = RandomGenerator.Next(1, 6);
                }
            }

            return dieArray;
        }
    }
}