using System.ComponentModel.DataAnnotations;

namespace VegeFood.Support
{
    
    public sealed class IncludeArray: ValidationAttribute
    {
        public object[] CheckArray { get; set; }

        public override bool IsValid(object value)
        {
            if (CheckArray == null) return true;
            bool result = false;
            foreach(object item in CheckArray)
                if(value == item)
                {
                    result = true;
                    break;
                }
            return result;
        }
    }
}
