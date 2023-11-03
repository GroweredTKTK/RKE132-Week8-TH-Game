string folderPath = @"D:\Program Files\Visual Studio\DATA\";
string heroFile = "Heroes.txt";
string villainFile = "Villains.txt";
string weaponFile = "Weapons.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapons = File.ReadAllLines(Path.Combine(folderPath, weaponFile));


//string[] heroes = {"Mr.Incredible", "Billy Herington", "Batman"};
//string[] villains = { "Joker", "Patriot", "Barber", "Darth Vader", "Van Darkholme" };
//string[] weapons = { "Banana", "Spoon", "Pocket knife", "Tank" };

string hero = GetRandomValue(heroes);
string heroWeapon = GetRandomValue(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Your hero is {hero} ({heroHP})! Equipped with a {heroWeapon}.");

string villain = GetRandomValue(villains);
string villainWeapon = GetRandomValue(weapons);
int villainHP = GetCharacterHP(villain); 
int villainStrikeStrength = heroHP;
Console.WriteLine($"The Villain he fights against is {villain} ({villainHP})! Equipped with a {villainWeapon}.");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"{villain} wins!");
}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValue(string[] someArray)
{
    Random rand = new Random();
    int randomIndex = rand.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if((characterName).Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}