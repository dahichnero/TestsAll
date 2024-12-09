// See https://aka.ms/new-console-template for more information
using Shtirlitz;
using System.Diagnostics.Metrics;

var obj = new ShtirlitzClass();
obj.textkey = "аэрофотосъёмка ландшафта уже выявила земли богачей и процветающих крестьян";
string enc = obj.Encrypt("эволюция и деградация, что выберешь ты?");
Console.WriteLine(enc);
Console.WriteLine(obj.Decrypt(enc));

