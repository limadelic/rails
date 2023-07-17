namespace Examples;

class Messages
{
    public class User
    {
        public class Name
        {
            public const string Required = "user name is required";
            public const string MaxLength = "user name too long";
            public const string MinLength = "user name too short";
        }
        
        public class Pass
        {
            public const string Required = "pass is required";
            public const string MaxLength = "pass too long";
            public const string MinLength = "pass too short";
        }
    }
}