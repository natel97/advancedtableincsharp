Console.WriteLine("Type in a string");
string input;
input = Console.ReadLine();
if (input == "")
{
	Console.WriteLine("The String is empty!");
}
else if (input.Length < 5){
	Console.WriteLine("The string has less than 5 characters");
}
else if (input.Length < 10){
	Console.WriteLine("The string had at least 5 but less than 10 Characters.");
}
Console.WriteLine("The string was " + input);