// See https://aka.ms/new-console-template for more information
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Util;
using System.Text.Json;
using Microsoft.Extensions.Configuration; 

Console.WriteLine("Hello, World!");

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 

var adventOfCodeClient = new AdventOfCodeClient(configuration["Appsettings:AdventOfCodeSessionCookie"]);

DayOne.Solve(await adventOfCodeClient.GetInput(1)); 
DayTwo.Solve(await adventOfCodeClient.GetInput(2)); 
DayThree.Solve(await adventOfCodeClient.GetInput(3)); 

