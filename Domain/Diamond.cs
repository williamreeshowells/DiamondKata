using Domain.ValueObjects;
using System.Text;

namespace DiamondKata
{
	public class Diamond
	{
		private const char whiteSpaceCharacter = ' ';
		private const char letterA = 'A';

		public AlphabetIndex AlphabetIndex { get; private set; }

		public Diamond(AlphabetIndex alphabetIndex)
		{
			this.AlphabetIndex = alphabetIndex ?? throw new ArgumentNullException(nameof(alphabetIndex));
		}

		public string Draw()
		{
			return string.Join(
				separator: Environment.NewLine,
				values: this.BuildDiamondRows());
		}

		private List<string> BuildDiamondRows()
		{
			int indexOfLetterA = 0;

			// Build top half
			var rows = Enumerable.Range(indexOfLetterA, this.AlphabetIndex.Index + 1)
				.Select(x => this.BuildRow(x))
				.ToList();

			// Mirror top half skipping middle row to make bottom half
			rows.AddRange(rows.Take(this.AlphabetIndex.Index).Reverse());
			return rows;
		}

		private string BuildRow(int currentLetterIndex)
		{
			StringBuilder row = new StringBuilder();
			char currentRowLetter = (char)(letterA + currentLetterIndex);

			this.AddRowOuterWhiteSpace(row, currentLetterIndex);
			this.AddRowLetter(row, currentRowLetter);
			this.AddRowInnerWhiteSpace(row, currentLetterIndex, currentRowLetter);
			
			return row.ToString();
		}

		private void AddRowOuterWhiteSpace(StringBuilder row, int currentLetterIndex)
		{
			int noOfOuterWhiteSpaces = this.AlphabetIndex.Index - currentLetterIndex;
			row.Append(new string(whiteSpaceCharacter, noOfOuterWhiteSpaces));
		}

		private void AddRowLetter(StringBuilder row, char currentRowLetter)
		{
			row.Append(currentRowLetter);
		}

		private void AddRowInnerWhiteSpace(StringBuilder row, int currentLetterIndex, char currentRowLetter)
		{
			if (currentRowLetter == letterA)
			{
				return;
			}

			int noOfInnerWhiteSpaces = currentLetterIndex == letterA ? 0 : 2 * currentLetterIndex - 1;
			row.Append(new string(whiteSpaceCharacter, noOfInnerWhiteSpaces));
			row.Append(currentRowLetter);
		}
	}
}
