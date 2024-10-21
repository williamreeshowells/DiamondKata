namespace Domain.Tests.TestData
{
    public class ValidNonEnglishUnicodeLettersProvider
	{
        public static IEnumerable<object[]> GetTestData()
        {
			// ToDo: Create a random valid letter character generator so that these aren't all hard coded.
			// This will do for a quick tech test.
			yield return new object[] { 'À' };
			yield return new object[] { 'Á' };
			yield return new object[] { 'Â' };
			yield return new object[] { 'Ã' };
			yield return new object[] { 'Ä' };
			yield return new object[] { 'Å' };
			yield return new object[] { 'Æ' };
			yield return new object[] { 'Ç' };
			yield return new object[] { 'È' };
			yield return new object[] { 'É' };
			yield return new object[] { 'Ê' };
			yield return new object[] { 'Ë' };
			yield return new object[] { 'Ì' };
			yield return new object[] { 'Í' };
			yield return new object[] { 'Î' };
			yield return new object[] { 'Ï' };
			yield return new object[] { 'Ð' };
			yield return new object[] { 'Ñ' };
			yield return new object[] { 'Ò' };
			yield return new object[] { 'Ó' };
			yield return new object[] { 'Ô' };
			yield return new object[] { 'Õ' };
			yield return new object[] { 'Ö' };
			yield return new object[] { 'Ø' };
			yield return new object[] { 'Ù' };
			yield return new object[] { 'Ú' };
			yield return new object[] { 'Û' };
			yield return new object[] { 'Ü' };
			yield return new object[] { 'Ý' };
			yield return new object[] { 'Þ' };
			yield return new object[] { 'ß' };
		}
    }
}
