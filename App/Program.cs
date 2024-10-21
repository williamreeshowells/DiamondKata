namespace App
{
	using DiamondKata;
	using Domain.Tests.TestData;
	using Domain.ValueObjects;

	internal class Program
	{
		static async Task Main(string[] args)
		{
			// Reuse XUnit data generator from test project for simplicity.
			var lettersOfTheAlphabet = AlphabetIndexDataProvider.GetTestData();

			foreach (var letter in lettersOfTheAlphabet)
			{
				var alphabetIndex = (AlphabetIndex)letter[0];
				var diamond = new Diamond(alphabetIndex);
				var output = diamond.Draw();

				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("==================");
				Console.WriteLine($"Diamond For Letter {alphabetIndex.Letter}");
				Console.WriteLine(output);
				Console.WriteLine(Environment.NewLine);
				await Task.Delay(1000);
			}

			Console.ReadLine();
		}
	}
}
