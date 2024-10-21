namespace Domain.Tests.TestData
{
    public class SpecialCharacterDataProvider
    {
        public static IEnumerable<object[]> GetTestData()
        {
            // ToDo: Create a random special character generator so that these aren't all hard coded.
            // This will do for a quick tech test.
            yield return new object[] { '!' };
            yield return new object[] { '@' };
            yield return new object[] { '#' };
            yield return new object[] { '$' };
            yield return new object[] { '%' };
            yield return new object[] { '^' };
            yield return new object[] { '&' };
            yield return new object[] { '*' };
            yield return new object[] { '(' };
            yield return new object[] { ')' };
            yield return new object[] { '-' };
            yield return new object[] { '_' };
            yield return new object[] { '=' };
            yield return new object[] { '+' };
            yield return new object[] { '[' };
            yield return new object[] { ']' };
            yield return new object[] { '{' };
            yield return new object[] { '}' };
            yield return new object[] { '|' };
            yield return new object[] { '\\' };
            yield return new object[] { ':' };
            yield return new object[] { ';' };
            yield return new object[] { '\'' };
            yield return new object[] { '\"' };
            yield return new object[] { '<' };
            yield return new object[] { '>' };
            yield return new object[] { ',' };
            yield return new object[] { '.' };
            yield return new object[] { '?' };
            yield return new object[] { '/' };
            yield return new object[] { '`' };
            yield return new object[] { '~' };
            yield return new object[] { '¬' };
            yield return new object[] { '£' };
            yield return new object[] { '¢' };
            yield return new object[] { '¥' };
            yield return new object[] { '§' };
            yield return new object[] { '¶' };
            yield return new object[] { '©' };
            yield return new object[] { '®' };
            yield return new object[] { '™' };
            yield return new object[] { '±' };
            yield return new object[] { '×' };
            yield return new object[] { '÷' };
            yield return new object[] { 'µ' };
            yield return new object[] { 'º' };
            yield return new object[] { 'ª' };
            yield return new object[] { '•' };
        }
    }
}
