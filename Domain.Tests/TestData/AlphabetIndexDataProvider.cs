namespace Domain.Tests.TestData
{
	using Domain.ValueObjects;

	public class AlphabetIndexDataProvider
    {
        /// <summary>
        /// Provides every letter of the alphabet with it's zero based index to a unit test.
        /// This ensures that the unit test will test the diamond with every letter of the alphabet.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new AlphabetIndex('A'),};
            yield return new object[] { new AlphabetIndex('B'), };
            yield return new object[] { new AlphabetIndex('C'), };
            yield return new object[] { new AlphabetIndex('D'), };
            yield return new object[] { new AlphabetIndex('E'), };
            yield return new object[] { new AlphabetIndex('F'), };
            yield return new object[] { new AlphabetIndex('G'), };
            yield return new object[] { new AlphabetIndex('H'), };
            yield return new object[] { new AlphabetIndex('I'), };
            yield return new object[] { new AlphabetIndex('J'), };
            yield return new object[] { new AlphabetIndex('K'), };
            yield return new object[] { new AlphabetIndex('L'), };
            yield return new object[] { new AlphabetIndex('M'), };
            yield return new object[] { new AlphabetIndex('N'), };
            yield return new object[] { new AlphabetIndex('O'), };
            yield return new object[] { new AlphabetIndex('P'), };
            yield return new object[] { new AlphabetIndex('Q'), };
            yield return new object[] { new AlphabetIndex('R'), };
            yield return new object[] { new AlphabetIndex('S'), };
            yield return new object[] { new AlphabetIndex('T'), };
            yield return new object[] { new AlphabetIndex('U'), };
            yield return new object[] { new AlphabetIndex('V'), };
            yield return new object[] { new AlphabetIndex('W'), };
            yield return new object[] { new AlphabetIndex('X'), };
            yield return new object[] { new AlphabetIndex('Y'), };
            yield return new object[] { new AlphabetIndex('Z'), };
        }
    }
}