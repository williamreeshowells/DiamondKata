# Diamond Kata Test
This solution consists of one console app and two class libraries:
- App (Console App)
- Domain (Class Library)
- Domain.Tests (XUnit Class Library)

## Running The Solution
Run the console app project named App. It will generate and print a diamond for every letter in the alphabet to prove visually that the diamond generation succeeds.

## Domain
The domain consists of two objects
- Diamond (Generates a diamond string from a given letter)
- AlphabetIndex (Protects domain invariants surrounding acceptable input and mapping a given letter to an index in the alphabet to aid in diamond generation.

## Unit Tests
The following unit tests have been implemented:
- Happy path (Compare the output to a hard coded diamond string value)
- Assert that the outside of the diamond is drawn using letters only and that they are in the correct positions
- Assert the line count matches the expected count for a given letter
- Assert a diamond shape is drawn by checking the line length for each row
- Assert the correct number of outside whitespace characters are printed
- Assert the correct number of inside  whitespace characters are printed
- Check that the diamond is vertically symmetrical
- A diagnostic unit test that prints the diamonds to the test explorer output to view what is being drawn.


