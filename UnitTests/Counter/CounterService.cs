using System;

namespace Counter
{
    public class CounterService
    {
        public int GetMaxCountOfUniqueSequenceOfLetters(string sequence)
        {
            if (string.IsNullOrWhiteSpace(sequence))
            {
                throw new ArgumentNullException($"{sequence} is null");
            }

            int count = 1;
            int maxCount = 1;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (IsLatinSymbol(sequence[i]) && count == 0)
                {
                    count = 1;
                }

                if (IsLatinSymbol(sequence[i]) && sequence[i] != sequence[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        count = 1;
                    }
                }
            }

            return count > maxCount ? count : maxCount;
        }

        public int GetMaxCountOfTheSameLatinLetters(string sequence)
        {
            if (string.IsNullOrWhiteSpace(sequence))
            {
                throw new ArgumentNullException($"{sequence} is null");
            }

            int count = 1;
            int maxCount = 1;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (IsLatinSymbol(sequence[i]) && sequence[i] == sequence[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        count = 1;
                    }
                }
            }

            return count > maxCount ? count : maxCount;
        }

        public int GetMaxCountOfTheSameDigits(string sequence)
        {
            if (string.IsNullOrWhiteSpace(sequence))
            {
                throw new ArgumentNullException($"{sequence} is null");
            }

            int count = 1;
            int maxCount = 1;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (Char.IsDigit(sequence[i]) && count == 0)
                {
                    count = 1;
                }

                if (Char.IsDigit(sequence[i]) && sequence[i] == sequence[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        count = 0;
                    }
                }
            }

            return count > maxCount ? count : maxCount;
        }

        private bool IsLatinSymbol(char symbol)
        {
            return (symbol >= 'A' && symbol <= 'Z') ||
                (symbol >= 'a' && symbol <= 'z');
        }
    }
}

