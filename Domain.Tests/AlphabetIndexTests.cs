namespace Domain.Tests
{
	using Domain.Tests.TestData;
	using Domain.ValueObjects;
	using System;

	public class AlphabetIndexTests
	{
		/// <summary>
		/// Assert that special characters throw an argument out of range exception.
		/// </summary>
		/// <param name="specialCharacter"></param>
		[Theory]
		[MemberData(nameof(SpecialCharacterDataProvider.GetTestData), MemberType = typeof(SpecialCharacterDataProvider))]

		public void GivenASpecialCharacter_WhenConstructorCalled_ThenShouldThrowArgumentException(char specialCharacter)
		{
			// Act & Assert
			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new AlphabetIndex(specialCharacter));
			Assert.Equal("Only English letters from A to Z are allowed. (Parameter 'letter')", exception.Message);
		}
		/// <summary>
		/// Assert that numbers throw an argument out of range exception.
		/// </summary>
		[Fact]
		public void GivenANumber_WhenConstructorCalled_ThenShouldThrowArgumentException()
		{
			// Arrange
			var integerValue = new Random().Next();

			// Act & Assert
			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new AlphabetIndex((char)integerValue));
			Assert.Equal("Only English letters from A to Z are allowed. (Parameter 'letter')", exception.Message);
		}

		/// <summary>
		/// Assert that characters thatr are valid letters but not in the English alphabet throw an argument out of range exception.
		/// </summary>
		/// <param name="specialCharacter"></param>
		[Theory]
		[MemberData(nameof(SpecialCharacterDataProvider.GetTestData), MemberType = typeof(SpecialCharacterDataProvider))]

		public void GivenAValidNonEnglishLetter_WhenConstructorCalled_ThenShouldThrowArgumentException(char specialCharacter)
		{
			// Act & Assert
			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new AlphabetIndex(specialCharacter));
			Assert.Equal("Only English letters from A to Z are allowed. (Parameter 'letter')", exception.Message);
		}

		/// <summary>
		/// Assert that white space throws an argument out of range exception.
		/// </summary>
		[Fact]

		public void GivenWhiteSpace_WhenConstructorCalled_ThenShouldThrowArgumentException()
		{
			// Act & Assert
			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new AlphabetIndex(letter: ' '));
			Assert.Equal("Letter cannot be empty or whitespace. (Parameter 'letter')", exception.Message);
		}
	}
}
