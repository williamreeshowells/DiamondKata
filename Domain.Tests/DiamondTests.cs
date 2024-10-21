namespace Domain.Tests
{
	using DiamondKata;
	using Domain.Tests.TestData;
	using Domain.ValueObjects;
	using FluentAssertions;
	using Xunit.Abstractions;

	public class DiamondTests
	{
		private readonly ITestOutputHelper outputHelper;

		public DiamondTests(ITestOutputHelper outputHelper)
		{
			this.outputHelper = outputHelper;
		}

		/// <summary>
		/// Test the happy path.
		/// </summary>
		[Fact]
		public void GivenTheLetterG_WhenDrawCalled_ThenShouldDrawDiamondAsExpected()
		{
			string diamond = "      A\r\n" +
							 "     B B\r\n" +
							 "    C   C\r\n" +
							 "   D     D\r\n" +
							 "  E       E\r\n" +
							 " F         F\r\n" +
							 "G           G\r\n" +
							 " F         F\r\n" +
							 "  E       E\r\n" +
							 "   D     D\r\n" +
							 "    C   C\r\n" +
							 "     B B\r\n" +
							 "      A";


			// Act
			var alphabetIndex = new AlphabetIndex('G');
			var result = new Diamond(alphabetIndex).Draw();

			// Assert
			result.Should().Be(diamond);
		}

		/// <summary>
		/// Assert that the diamond has the correct line count.
		/// The correct line count is double the letter's zero based position in the alphabet plus one.
		/// e.g. the zero based position of the letter C is 2. So (2 + 2) + 1 = 5. 
		/// e.g. (2 rows for A) + (2 rows for B) + (1 row for C) = 5.
		/// Run this for every letter in the alphabet using the AlphabetIndexDataProvider.
		/// </summary>
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void GivenALetter_WhenDrawIsCalled_ThenShouldHaveTheCorrectRowCountForTheLetter(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();
			var lines = result.Split(Environment.NewLine);

			// Assert
			var expectedLineCount = (alphabetIndex.Index + 1) + alphabetIndex.Index;
			lines.Should().HaveCount(expectedLineCount);

		}

		/// <summary>
		/// Assert that for each row printed that the row's line length is the expected
		/// line length to make a diamond shape when printed.
		/// Only test the first half of the diamond. We will check symmetry in another test.
		/// </summary>
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void GivenALetter_WhenDrawIsCalled_ThenTheLineLengthForEachRowIsCorrect(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();

			// Assert
			var lines = result.Split(Environment.NewLine);

			var lettersUsedToPrintDiamond = AlphabetIndexDataProvider.GetTestData()
				.SelectMany(x => x)
				.Select(x => (AlphabetIndex)x)
				.Where(x => x.Index <= alphabetIndex.Index)
				.OrderBy(x => x.Index)
				.ToList();

			for (int lineIndex = 0; lineIndex <= alphabetIndex.Index; lineIndex++)
			{
				var line = lines[lineIndex];
				var letter = lettersUsedToPrintDiamond[lineIndex];
				var expectedLineLength = letter.Index + lettersUsedToPrintDiamond.Count();
				line.Length.Should().Be(expectedLineLength);
			}
		}

		/// <summary>
		/// Assert that the outside characters are letters and printed in the expected positions.
		/// Only test the first half of the diamond. We will check symmetry in another test.
		/// </summary>
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void GivenALetter_WhenDrawIsCalled_ThenTheOutsideLettersArePrintedAtTheExpectedPositions(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();

			// Assert
			var lines = result.Split(Environment.NewLine);

			var lettersUsedToPrintDiamond = AlphabetIndexDataProvider.GetTestData()
				.SelectMany(x => x)
				.Select(x => (AlphabetIndex)x)
				.Where(x => x.Index <= alphabetIndex.Index)
				.OrderBy(x => x.Index)
				.ToList();

			for (int lineIndex = 0; lineIndex <= alphabetIndex.Index; lineIndex++)
			{
				var line = lines[lineIndex];
				var letter = lettersUsedToPrintDiamond[lineIndex];

				var leftCharacterIndex = alphabetIndex.Index - lineIndex;
				var rightCharacterIndex = line.Length - 1;

				char.IsLetter(line[leftCharacterIndex]).Should().BeTrue();
				char.IsLetter(line[rightCharacterIndex]).Should().BeTrue();
			}
		}

		/// <summary>
		/// Assert that the outside white space characters are printed in the correct places.
		/// Only test the first half of the diamond. We will check symmetry in another test.
		/// </summary>
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void GivenALetter_WhenIsDrawCalled_ThenShouldPrintTheCorrectOutsideWhiteSpaceCharacters(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();

			// Assert
			var lines = result.Split(Environment.NewLine);

			// Assert
			for (int currentLetterIndex = 0; currentLetterIndex <= alphabetIndex.Index; currentLetterIndex++)
			{
				int expectedOuterSpaces = alphabetIndex.Index - currentLetterIndex;
				int expectedInnerSpaces = currentLetterIndex == 0 ? 0 : 2 * currentLetterIndex - 1;
				var currentLine = lines[currentLetterIndex];
				var whiteSpaces = currentLine.TakeWhile(c => c == ' ');
				whiteSpaces.Should().HaveCount(expectedOuterSpaces);
			}
		}

		/// <summary>
		/// Assert that the inside white space characters are printed in the correct places.
		/// Only test the first half of the diamond. We will check symmetry in another test.
		/// </summary>
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void GivenALetter_WhenDrawIsCalled_ThenShouldPrintTheCorrectInsideWhiteSpaceCharacters(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();

			// Assert
			var lines = result.Split(Environment.NewLine);

			// Assert
			for (int currentLetterIndex = 0; currentLetterIndex <= alphabetIndex.Index; currentLetterIndex++)
			{
				int expectedOuterSpaces = alphabetIndex.Index - currentLetterIndex;
				int expectedInnerSpaces = currentLetterIndex == 0 ? 0 : 2 * currentLetterIndex - 1;
				var currentLine = lines[currentLetterIndex];

				if (currentLetterIndex > 'A')
				{
					int firstLetterIndex = expectedOuterSpaces;
					int secondLetterIndex = firstLetterIndex + expectedInnerSpaces + 1;
					string innerSpacesSection = currentLine.Substring(firstLetterIndex + 1, expectedInnerSpaces);
					string expectedInnderSpaceSection = new string(' ', expectedInnerSpaces);
					innerSpacesSection.Should().Be(expectedInnderSpaceSection);
				}
			}
		}

		/// <summary>
		/// Assert that the diamond is vertically symmetrical.
		/// No need to test horizontal symmetry as we tested the left
		/// and right characters are in the expected positions above and
		/// that the whitespace is correct.
		/// </summary>
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void GivenALetter_WhenDrawIsCalled_ThenTheDiamondIsVerticallySymmetrical(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();

			// Assert
			var lines = result.Split(Environment.NewLine);

			for (int i = 0; i < lines.Length / 2; i++)
			{
				var topLine = lines[i];
				var bottomLine = lines[lines.Length - 1 - i];

				topLine.Should().Be(bottomLine);
			}
		}

		/// <summary>
		/// View output in test explorer results.
		/// <param name="alphabetIndex">The zero based alphabet index map for the letter under test.</param>
		[Theory]
		[MemberData(nameof(AlphabetIndexDataProvider.GetTestData), MemberType = typeof(AlphabetIndexDataProvider))]
		public void PrintDiamondsForDiagnostics(AlphabetIndex alphabetIndex)
		{
			// Act
			var result = new Diamond(alphabetIndex).Draw();
			this.outputHelper.WriteLine(result);
		}
	}
}