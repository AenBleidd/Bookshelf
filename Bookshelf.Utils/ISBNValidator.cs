namespace Bookshelf.Utils
{
  public static class ISBNValidator
  {
    // ********************************************************************
    // * ISBN Reference:                                                  *
    // * http://en.wikipedia.org/wiki/International_Standard_Book_Number  *
    // ********************************************************************

    /// <summary>
    /// This method will validate a ISBN 10
    /// or ISBN 13 code
    /// or ISSN code.
    /// </summary>
    /// <param name="isbn">code to validate</param>
    /// <returns>true, if valid, otherwise false</returns>
    public static bool TryValidate(string isbn)
    {
      if (!string.IsNullOrEmpty(isbn))
      {
        if (isbn.Contains("-")) isbn = isbn.Replace("-", "");

        switch (isbn.Length)
        {
          case 8: return IsValidIssn(isbn);
          case 10: return IsValidIsbn10(isbn);
          case 13: return IsValidIsbn13(isbn);
        }
      }
      return false;
    }

    /// <summary>
    /// Validates ISSN codes
    /// </summary>
    /// <param name="issn">code to validate</param>
    /// <returns>true if valid</returns>
    private static bool IsValidIssn(string issn)
    {
      if (!string.IsNullOrEmpty(issn))
      {
        if (issn.Contains("-")) issn = issn.Replace("-", "");

        long j;

        // Length must be 8 and only the last character could be a char('X') or a numeric value,
        // otherwise it's not valid.
        if (issn.Length != 8 || !long.TryParse(issn.Substring(0, issn.Length - 1), out j))
          return false;

        var lastChar = issn[issn.Length - 1];

        // Using the alternative way of calculation
        var sum = 0;
        for (var i = 0; i < 7; i++)
          sum += int.Parse(issn[i].ToString()) * (i + 1);

        // Getting the remainder or the checkdigit
        var remainder = sum % 11;

        // If the last character is 'X', then we should check if the checkdigit is equal to 10
        if (lastChar == 'X')
          return (remainder == 10);
        // Otherwise check if the lastChar is numeric
        // Note: I'm passing sum to the TryParse method to not create a new variable again
        else if (int.TryParse(lastChar.ToString(), out sum))
          // lastChar is numeric, so let's compare it to remainder
          return (remainder == int.Parse(lastChar.ToString()));
      }

      return false;
    }

    /// <summary>
    /// Validates ISBN10 codes
    /// </summary>
    /// <param name="isbn10">code to validate</param>
    /// <returns>true if valid</returns>
    private static bool IsValidIsbn10(string isbn10)
    {
      if (!string.IsNullOrEmpty(isbn10))
      {
        if (isbn10.Contains("-")) isbn10 = isbn10.Replace("-", "");

        long j;

        // Length must be 10 and only the last character could be a char('X') or a numeric value,
        // otherwise it's not valid.
        if (isbn10.Length != 10 || !long.TryParse(isbn10.Substring(0, isbn10.Length - 1), out j))
          return false;

        var lastChar = isbn10[isbn10.Length - 1];

        // Using the alternative way of calculation
        var sum = 0;
        for (var i = 0; i < 9; i++)
          sum += int.Parse(isbn10[i].ToString()) * (i + 1);

        // Getting the remainder or the checkdigit
        var remainder = sum % 11;

        // If the last character is 'X', then we should check if the checkdigit is equal to 10
        if (lastChar == 'X')
          return (remainder == 10);
        // Otherwise check if the lastChar is numeric
        // Note: I'm passing sum to the TryParse method to not create a new variable again
        else if (int.TryParse(lastChar.ToString(), out sum))
          // lastChar is numeric, so let's compare it to remainder
          return (remainder == int.Parse(lastChar.ToString()));
      }

      return false;
    }

    /// <summary>
    /// Validates ISBN13 codes
    /// </summary>
    /// <param name="isbn13">code to validate</param>
    /// <returns>true, if valid</returns>
    private static bool IsValidIsbn13(string isbn13)
    {
      if (!string.IsNullOrEmpty(isbn13))
      {
        if (isbn13.Contains("-")) isbn13 = isbn13.Replace("-", "");

        // If the length is not 13 or if it contains any non numeric chars, return false
        long temp;
        if (isbn13.Length != 13 || !long.TryParse(isbn13, out temp)) return false;

        // Comment Source: Wikipedia
        // The calculation of an ISBN-13 check digit begins with the first
        // 12 digits of the thirteen-digit ISBN (thus excluding the check digit itself).
        // Each digit, from left to right, is alternately multiplied by 1 or 3,
        // then those products are summed modulo 10 to give a value ranging from 0 to 9.
        // Subtracted from 10, that leaves a result from 1 to 10. A zero (0) replaces a
        // ten (10), so, in all cases, a single check digit results.
        var sum = 0;
        for (var i = 0; i < 12; i++)
        {
          sum += int.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
        }

        var remainder = sum % 10;
        var checkDigit = 10 - remainder;
        if (checkDigit == 10) checkDigit = 0;

        return (checkDigit == int.Parse(isbn13[12].ToString()));
      }

      return false;
    }
  }
}
