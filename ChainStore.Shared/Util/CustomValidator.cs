using System;

namespace ChainStore.Shared.Util
{
    public static class CustomValidator
    {
        public static void ValidateId(Guid id)
        {
            if(id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
        }

        public static void ValidateId(Guid? id)
        {
            if(id.HasValue && id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
        }

        public static void ValidateString(string str, int minLength, int maxLength)
        {
            if(string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            if(str.Length < minLength || str.Length > maxLength) throw new ArgumentException(nameof(str));
        }

        public static void ValidateNumber(int number, int minValue, int maxValue)
        {
            if(number < minValue || number > maxValue) throw new ArgumentException(nameof(number));
        }

        public static void ValidateNumber(double number, double minValue, double maxValue)
        {
            if (number < minValue || number > maxValue) throw new ArgumentException(nameof(number));
        }

        public static void ValidateObject<T>(T obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));
        }
    }
}