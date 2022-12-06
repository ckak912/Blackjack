namespace Blackjack.Test.TestingData;

public class PlayerInputTestData
{
    public static IEnumerable<object[]> GoodPlayerInputData =>
        new List<object[]>
        {
            new object[] { new List<string> { "1" }, "1" },
            new object[] { new List<string> { "0" }, "0" },
        };

    public static IEnumerable<object[]> PlayerInputData =>
        new List<object[]>
        {
            new object[] { new List<string> { "abc" ,"1"}, "1"},
            new object[] { new List<string> { "123" , "xyz", "", "0"}, "0" },
            new object[] { new List<string> { "8", "a","1" }, "1" },
            new object[] { new List<string> { "11", "", "0" }, "0" },
            new object[] { new List<string> { "1", "%", "1" }, "1" },
        };

    public static IEnumerable<object[]> CallingData =>
        new List<object[]>
        {
            new object[] { new List<string> { "abc", "1" }, "1" },
            new object[] { new List<string> { "123", "xyz", "", "0" }, 3 },
            new object[] { new List<string> { "8", "a", "1" }, 2 },
            new object[] { new List<string> { "11", "", "0" }, 2 },
        };
}