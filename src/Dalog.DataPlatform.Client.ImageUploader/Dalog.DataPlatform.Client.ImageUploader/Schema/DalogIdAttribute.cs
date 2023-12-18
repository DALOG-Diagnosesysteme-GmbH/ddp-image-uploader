namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DalogIdAttribute : ValidationAttribute
    {
        public DalogIdAttribute()
            : base("Provided value is not a valid DalogId in the format 00-000-00")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value is null) return false;

            var str = value.ToString();
            if (string.IsNullOrWhiteSpace(str)) return false;

            var splitStr = str.Split(new char[] { '-', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitStr.Length != 3 && splitStr.Length != 4)
            {
                return false;
            }

            if (splitStr[0].Length != 2 || !splitStr[0].All(char.IsDigit))
            {
                return false;
            }

            if (splitStr[1].Length != 3 || !splitStr[1].All(char.IsDigit))
            {
                return false;
            }

            if (splitStr[2].Length != 2 || !splitStr[2].All(char.IsDigit))
            {
                return false;
            }

            if (splitStr.Length == 4 && (splitStr[3].Length != 1 || !splitStr[3].All(char.IsDigit)))
            {
                return false;
            }

            return true;
        }
    }
}
