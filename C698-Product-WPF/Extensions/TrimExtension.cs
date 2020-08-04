namespace C698_Product_WPF.Extensions
{
  public static class TrimExtension
  {
    public static string TrimFix(this string rawString)
    {
      if (!string.IsNullOrWhiteSpace(rawString))
      {
        return rawString.Trim();
      }
      return null;
    }
  }
}
