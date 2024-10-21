namespace Domain.ValueObjects
{
	/// <summary>
	/// Value object responsible for ensuring domain invariants
	/// surrounding acceptable input and calculation of alphabet indexes.
	/// </summary>
	public record AlphabetIndex
	{
		public AlphabetIndex(char letter)
		{
			// Guard clauses
			this.AssertNotWhiteSpace(letter);
			this.AssertEnglishAlphabet(letter);

			this.Letter = char.ToUpper(letter);
			this.Index = this.CalculateAlphabetIndex(Letter);
		}

		public char Letter { get; set; }

		public int Index { get; set; }

		private void AssertNotWhiteSpace(char letter)
		{
			if (char.IsWhiteSpace(letter))
			{
				throw new ArgumentOutOfRangeException(
					paramName: nameof(letter),
					message: "Letter cannot be empty or whitespace.");
			}
		}

		private void AssertEnglishAlphabet(char letter)
		{
			if (letter < 'A' || letter > 'Z')
			{
				throw new ArgumentOutOfRangeException(
					paramName: nameof(letter),
					message: "Only English letters from A to Z are allowed.");
			}
		}

		private int CalculateAlphabetIndex(char letter)
		{
			return letter - 'A';
		}
	}
}