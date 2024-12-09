// See https://aka.ms/new-console-template for more information
using Shtirlitz;
using System.Diagnostics.Metrics;

var obj = new ShtirlitzClass();
obj.textkey = "съешь же ещё этих мягких французских булок, да выпей чаю.";
string from = File.ReadAllText("test.txt");
string enc = obj.Encrypt(from);
Console.WriteLine(enc);
Console.WriteLine(obj.Decrypt(enc));

