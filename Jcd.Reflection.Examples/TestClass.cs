// ReSharper disable ConvertToAutoPropertyWhenPossible
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

using Jcd.Reflection.Examples;

[assembly:MyDescription("A cool assembly you really should check out sometime.")]
[assembly:MyDescription("It's the best ever!")]
[assembly:MyDescription("You'll love it!")]

[module:MyDescription("This module is a great example of something! I'm not sure what tho.")]

namespace Jcd.Reflection.Examples
{
    [MyDescription("A Test Class")]
    [MyDescription("A useful Class")]
    public class TestClass
    {
        [MyDescription("A useful field")]
        [MyDescription("No you don't get to know what it's used for.")]

        private int _field;
        
        [MyDescription("Nobody else should access this!")]
        [MyDescription("It's mine all mine!")]
        private int PrivateProperty { 
            get=>_field;
            set => _field = value;
        }

        [MyDescription("A helper method that only I know about.")]
        private int InternalGetField() => _field;

        [MyDescription("This is how the world gets to know about the value of _field")]
        [MyDescription("The world isn't ready to do it any other way")]
        public int GetField() => InternalGetField();
    }
}
