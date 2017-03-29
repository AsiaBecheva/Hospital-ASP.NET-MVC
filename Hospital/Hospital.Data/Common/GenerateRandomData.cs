namespace Hospital.Data
{
    using System;
    using System.Text;

    public class GenerateRandomData
    {
        private const string LETTERS = "ABCDEFJQEadffhjkiWRRTYUgftrIOPMNLK";
        private Random random;

        public GenerateRandomData()
        {
            this.random = new Random();
        }

        public string RandomDataString(int min = 10, int max = 50)
        {
            var result = new StringBuilder();
            var length = this.random.Next(min, max);
            for (int i = 0; i < length; i++)
            {
                result.Append(LETTERS[this.random.Next(0, LETTERS.Length-1)]);
            }

            return result.ToString();
        }

        public int RandomDataInt(int min, int max)
        {
            return this.random.Next(min, max); 
        }
    }
}
