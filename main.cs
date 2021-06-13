using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Text;
using System.Net;
using System.Media;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Timers;
using System.Security.Cryptography;
using System.Dynamic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;


class MainClass {
  
  static ConsoleKeyInfo keyInput;
  static int currentEnemyAttack;
   static int weaponDamage;
      static string LevelCode;
      static int killsLeft;
      static string spellDamageCode;
      static string weaponEquipped;
      static int armor;
      static int Damage;
      static string armorEquipped;
      static int EnemyKills;
      static int PlayerHp;
      static int CurrentEnemyHp;
      static int spellCasts;
      static string spellEquipped;
      static int spellDamage;
      static string password = "&2749^#m2";
static string superPassword = "28?7946%*&(6#2094+-_%$$#!";
      static string CurrentState;
      static string Name;
      static string LandName = "Bunnytoesia";
      static string Input;
      static string codeOutput;
      static string weaponDamageCode;
      static string ArmorCode;
      static string spellCastsCode;
      static string goldCode;
      static int gold = 0;
      static int playerLevel = 1;
      static bool isBossFighting;
      static string currentEnemyName;
         static string[] Lvl1monsterNames = {"Goblin", "Bull", "Rat", "Evil puppy"};
      static int[] Lvl1monsterAtkDamage = {5, 7, 4, 6};
      static int[] Lvl1monsterHP = {7, 13, 5, 10};
      static string[] Lvl2monsterNames = {"Zombie Rat", "Big Goblin", "Black Bear", "Evil Bull"};
      static int[] Lvl2monsterAtkDamage = {5, 7, 8, 7};
      static int[] Lvl2monsterHP = {7, 13, 15, 13};
      static int randNum;
      static string[] Lvl3monsterNames = {"Large Troll","Small HobGoblin", "Death Bear", "Knight"};
      static int[] Lvl3monsterAtkDamage = {10, 11, 12, 8};
      static int[] Lvl3monsterHP = {19, 15, 16, 13};
      static string[] Lvl4monsterNames = {"Large Moth", "Angry mob", "Wizard", "HobGoblin"};
      static int[] Lvl4monsterAtkDamage = {11, 10, 13, 12};
      static int[] Lvl4monsterHP = {17, 18, 21, 19};
      static string[] Lvl5monsterNames = {"Ranger", "Posessed Spirit", "Evil Sprite", "Evil Wizard"};
      static int[] Lvl5monsterAtkDamage = {16, 14, 15, 18};
      static int[] Lvl5monsterHP = {25, 23, 24, 27};
 
    public static void Main (string[] args) {
        CurrentState = "Character select";
        StartGame();
        LoadMainMenu();
      }

      public static void LoadMainMenu(){
        


        if(PlayerHp <= 0){
          Clear();
          ForegroundColor = ConsoleColor.Red;
          WriteLine($"You died on your quest in {LandName}");
          WriteLine("You Lose!");
          Thread.Sleep(3000);
         while(PlayerHp <= 0){
            Environment.Exit(0);
          }
          ReadLine();
        }
        CurrentState = "Main Menu";
        Clear();
        ForegroundColor = ConsoleColor.Blue;
        WriteLine(Name + ", Welcome to the land of " + LandName + "");
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Gold: " + gold + "");
        WriteLine("Level: " + playerLevel + "");
        WriteLine("Weapon Damage: " + weaponDamage + "");
        WriteLine("Weapon Equipped: " + weaponEquipped + "");
        WriteLine("Spell Damage: " + spellDamage + "");
        WriteLine("Spell Equipped: " + spellEquipped + "");
        WriteLine("Spell casts left: " + spellCasts + "");
        WriteLine("Armor: " + armor + "");
        WriteLine("Armor Equipped: " + armorEquipped + "");
        WriteLine("HP: " + PlayerHp + "");
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("Where would you like to go?");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[0] Armory.");
        WriteLine("[1] Sorceror's lair");
        if(playerLevel < 6){
          WriteLine("[2] Enter Bunnytoesia");
        }else{
          WriteLine("[2] Adventure Bunnytoesia");
        }
        WriteLine("[3] Restore HP");
        WriteLine("[4] Level up");
        WriteLine("[5] Save/Load Game");
        WriteLine("[6] Quit game");
        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine("press the keys for what you want to do");
        ForegroundColor = ConsoleColor.White;
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          DaArmory();
        }else if(keyInput.KeyChar == '1'){
          SorcerorLand();
        }else if(keyInput.KeyChar == '2'){
          if(playerLevel < 6){
            EnterBunnytoesia();
          }
          else
          {
            EnterTown();
          }
        }else if(keyInput.KeyChar == '3'){
          Hospital();
        }else if(keyInput.KeyChar == '4'){
          LevelUp();
        }else if(keyInput.KeyChar == '#'){
          Cheats();
        }else if(keyInput.KeyChar == '5'){
          SaveLoad();
        }
        else if (keyInput.KeyChar == '6')
        {
          QuitGame();
        }
        else{
          LoadMainMenu();
        }
      }

      public static void StartGame(){
        Clear();
        isBossFighting = false;
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("This was inspired and I used a little bit of code from a game called The Long Wastes of Fatholad, play it https://replit.com/@CORBINCARTWRIGH/The-Long-Wastes-of-Fatholad?v=1 and the person who made it is @CORBINCARTWRIGH");
        Thread.Sleep(6500);
        Clear();
        WriteLine("Please enter your name");
        Name = ReadLine();
        spellEquipped = "NONE";
        spellDamage = 0;
        spellCasts = 0;
        PlayerHp = 100;
        weaponDamage = 5;
        weaponEquipped = "Old Dagger";
        armor = 0;
        armorEquipped = "NONE";
        CurrentState = "Main Menu";
      }
      public static void QuitGame ()
      {
        ForegroundColor = ConsoleColor.DarkRed;
        
        Clear();
        WriteLine("Game quit");
        Thread.Sleep(3000);
        Clear();
        Environment.Exit(0);
        
      }

      public static void DaArmory(){
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Gold: " + gold + "\n");
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Welcome to the Armory!");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[0] return to " + LandName + "");
        WriteLine("[1] Purchase sword.");
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Damage:8\nCost:25g");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[2] Purchase Shield");
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Armor:2\nCost:30g");
        ForegroundColor = ConsoleColor.Green;
        if(playerLevel >= 3){
          WriteLine("[3] Purchase Blade");
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("Damage:10\nCost:40g");
        }
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("press the keys for what you want to do");
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          LoadMainMenu();
        }else if(keyInput.KeyChar == '1'){
          if(gold < 25){
            Clear();
            WriteLine("Sorry you don't have enough gold");
            ReadKey();
            DaArmory();
          }else{
            Clear();
            WriteLine("Purchase successful!");
            ReadKey();
            weaponDamage = 8;
            gold -= 25;
            weaponEquipped = "Sword";
            DaArmory();
          }
        }else if(keyInput.KeyChar == '2'){
          if(gold < 30){
            Clear();
            WriteLine("Sorry you don't have enough gold");
            ReadKey();
            DaArmory();
          }else{
            Clear();
            WriteLine("Purchase successful!");
            ReadKey();
            armor = 2;
            gold -= 30;
            armorEquipped = "Shield";
            DaArmory();
          }
        }else if(keyInput.KeyChar == '3' && playerLevel >= 3){
          if(gold < 40){
            Clear();
            WriteLine("Sorry you don't have enough gold");
            ReadKey();
            DaArmory();
          }else{
            Clear();
            WriteLine("Purchase successful!");
            ReadKey();
            weaponDamage = 10;
            gold -= 40;
            weaponEquipped = "Blade";
            DaArmory();
          }
        }else{
          DaArmory();
        }
      }

      public static void SorcerorLand(){
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Gold: " + gold);
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Welcome to Sorceror's Land!");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[0] Return to " + LandName);
        WriteLine("[1] Purchase HeatWave spell");
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Damage:10\nCost:30g");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[2] Purchase Dark-Bone Shield");
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Armor:4\nCost:50g");
        if(playerLevel >= 3){
          ForegroundColor = ConsoleColor.Green;
          WriteLine("[3] Purchase Freeze Spell");
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("Damage:15\nCost:45g");
        }
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("press the keys for what you want to do");
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          LoadMainMenu();
        }else if(keyInput.KeyChar == '1'){
          if(gold < 30){
            Clear();
            WriteLine("Sorry you don't have enough gold");
            ReadKey();
            SorcerorLand();
          }else{
            Clear();
            WriteLine("Purchase successful");
            ReadKey();
            spellDamage = 10;
            gold -= 30;
            spellEquipped = "HeatWave";
            spellCasts = 5;
            SorcerorLand();
          }
        }else if(keyInput.KeyChar == '2'){
          if(gold < 50){
            Clear();
            WriteLine("Sorry you don't have enough gold");
            ReadKey();
            SorcerorLand();
          }else{
            Clear();
            WriteLine("Purchase successful");
            ReadKey();
            gold -= 50;
            armor = 4;
            armorEquipped = "Dark-Bone Shield";
            SorcerorLand();
         }
        }else if(keyInput.KeyChar == '3' && playerLevel >= 3){
          if(gold < 45){
            Clear();
            WriteLine("Sorry you don't have enough gold");
            ReadKey();
            SorcerorLand();
          }else{
            Clear();
            WriteLine("Purchase successful!");
            gold -= 45;
            spellDamage = 15;
            spellCasts = 6;
            spellEquipped = "Freeze";
            SorcerorLand();
          }
        }
      }

      public static void EnterBunnytoesia(){
        Clear();
        ForegroundColor = ConsoleColor.Red;
        Random random = new Random(); 
        randNum = random.Next(0, Lvl1monsterNames.Length);
        if (armor == 1)
        {
          currentEnemyAttack -= 1;
        }
        if (armor == 2)
        {
          currentEnemyAttack -= 2;
        }
        if (armor == 3)
        {
          currentEnemyAttack -= 3;
        }
        if (armor == 4)
        {
          currentEnemyAttack -= 4;
        }
        if (armor == 5)
        {
          currentEnemyAttack -= 5;
        }
        if (armor == 6)
        {
          currentEnemyAttack -= 6;
        }
        if(playerLevel == 1){
          WriteLine("You enter Bunnytoesia and encounter a " + Lvl1monsterNames[randNum] + "!");
          currentEnemyName = Lvl1monsterNames[randNum];
          CurrentEnemyHp = Lvl1monsterHP[randNum];
          currentEnemyAttack = Lvl1monsterAtkDamage[randNum];
        }else if(playerLevel == 2){
          WriteLine($"You enter the dark part of {LandName} and encounter a " + Lvl2monsterNames[randNum] + "!");
          currentEnemyName = Lvl2monsterNames[randNum];
          currentEnemyAttack = Lvl2monsterAtkDamage[randNum];
          CurrentEnemyHp = Lvl2monsterHP[randNum];
        }else if(playerLevel == 3){
          WriteLine("You enter the deep wasteLands of Bunnytoesia and encounter a " + Lvl3monsterNames[randNum] + "!");
          currentEnemyName = Lvl3monsterNames[randNum];
          currentEnemyAttack = Lvl3monsterAtkDamage[randNum];
          CurrentEnemyHp = Lvl3monsterHP[randNum];
        }else if(playerLevel == 4){
          WriteLine("You enter the deepest wastelands of Bunnytoesia and encounter a " + Lvl4monsterNames[randNum] + "!");
          currentEnemyName = Lvl4monsterNames[randNum];
          currentEnemyAttack = Lvl4monsterAtkDamage[randNum];
          CurrentEnemyHp = Lvl4monsterHP[randNum];
        }else if(playerLevel == 5 && killsLeft != 1){
          WriteLine("You enter the entangled Forests of Bunnytoesia and encounter a " + Lvl5monsterNames[randNum] + "!");
          currentEnemyName = Lvl5monsterNames[randNum];
          currentEnemyAttack = Lvl5monsterAtkDamage[randNum];
          CurrentEnemyHp = Lvl5monsterHP[randNum];
        }else if(playerLevel == 5 && killsLeft == 1){
          WriteLine("THE LAST MONSTER IS THE SOUL OF Bunnytoesia!!!");
          currentEnemyName = "Soul Of Bunnytoesia";
          PlayerHp = 125;
          currentEnemyAttack = 20;
          CurrentEnemyHp = 100;
        }
        ReadKey();
        Clear();
        while(CurrentEnemyHp >= 1){
          Clear();
          WriteLine("Enemy Hp: " + CurrentEnemyHp);
          ForegroundColor = ConsoleColor.Green;
          if(currentEnemyName != "Soul Of Bunnytoesia" && currentEnemyName != "Evil Dog Wizard"){
            WriteLine("[0] evade");
          }
          WriteLine("[1] Attack with weapon");
          if(spellCasts >= 1 && spellEquipped != "NONE"){
            WriteLine("[2] Attack with spell");
          }
          keyInput = ReadKey();
          if(keyInput.KeyChar == '0'){
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("You evade, but not before it attacks you. You suffer " + currentEnemyAttack + "Damage");
            ReadKey();
            PlayerHp -= currentEnemyAttack;
            LoadMainMenu();
          }else if(keyInput.KeyChar == '1'){
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            if(currentEnemyName == "Soul Of Bunnytoesia" && CurrentEnemyHp <= 50){
              WriteLine("The Soul Of Bunnytoesia blocks some of your attack");
              randNum = random.Next(weaponDamage - 3, weaponDamage);
              WriteLine("The enemy takes " + randNum + " Damage"); 
            }else{
              randNum = random.Next(weaponDamage - 1, weaponDamage + 1);
              WriteLine("The enemy takes " + randNum + " Damage");
            }
            ReadKey();
            CurrentEnemyHp -= randNum;
          }else if(spellCasts >= 1){
            if(keyInput.KeyChar == '2'){
              Clear();
              ForegroundColor = ConsoleColor.Yellow;
              WriteLine("You use your spell against it. It takes " + spellDamage + "Damage");
              CurrentEnemyHp -= spellDamage;
              spellCasts -= 1;
              ReadKey();
            }
          }
          Clear();
          ForegroundColor = ConsoleColor.Red;
          Damage = currentEnemyAttack;
          Damage -= armor;
          PlayerHp -= Damage;
          WriteLine("The enemy attacks you dealing " + Damage + " Damage");
          WriteLine("You have " + PlayerHp + " HP left");
          
          if(PlayerHp <= 0){
            Death();
          }
          ReadKey();
        }
        Clear();
        if(playerLevel == 1 && currentEnemyName == "Rat"){
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("No Loot was found");
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 1 && currentEnemyName == "Bull"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 4);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 6);
          if(randNum == 5){
            WriteLine("On the ground lays some Bull armor.");
            WriteLine("[0] leave it");
            WriteLine("[1] take it");
            WriteLine("Get Bull armor with armor + 1");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("Bull Armor Obtained!");
              armorEquipped = "Bull Armor";
              armor = 1;
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 1 && currentEnemyName == "Goblin"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 3);
          WriteLine("You gained " + randNum + " GOld!");
          gold += randNum;
          randNum = random.Next(1, 3);
          if(randNum == 2){
            WriteLine("On the ground lays a goblin sword");
            WriteLine("[0] leave it");
            WriteLine("[1] take it");
            WriteLine("Get goblin sword with Damage:6");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("Goblin Sword Obtained!");
              weaponEquipped = "Goblin Sword";
              weaponDamage = 6;
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 1 && currentEnemyName == "Evil puppy"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(2, 4);
          WriteLine("You gained " + randNum + " gold!");
          gold += randNum;
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 2 && currentEnemyName == "Evil Bull"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(2, 4);
          WriteLine("You gained " + randNum + " gold!");
          gold += randNum;
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 2){
          if(playerLevel == 2 && currentEnemyName == "Black Bear"){
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Nothing found");
            randNum = random.Next(1, 5);
            WriteLine("On the ground lays scraps of bear skin");
            WriteLine("[0] leave it");
            WriteLine("[1] take it");
            WriteLine("Get Bear skin with Armor + 2");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("Bear skin Obtained!");
              armorEquipped = "Bear skin";
              armor = 2;
            }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 2 && currentEnemyName == "Zombie Rat"){
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("No Loot found");
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 2 && currentEnemyName == "Big Goblin"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(3, 6);
          WriteLine("You gained " + randNum + " gold!");
          EnemyKills += 1;
          gold += randNum;
          ReadKey();
          LoadMainMenu();
        }
      }else if(playerLevel == 3){
        if(playerLevel == 3 && currentEnemyName == "Large Troll"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(2, 6);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 8);
          if(randNum == 4){
            WriteLine("The trolls club lays on the battlefield");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get Troll Club with Damage:12");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("Trolls club Obtained!");
              weaponDamage = 12;
              weaponEquipped = "Troll's Club";
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 3 && currentEnemyName == "Small HobGoblin"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 5);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 55);
          if(randNum == 25){
            WriteLine("On the floor lays a dark edged sword");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get Dark Edge with Damage:14");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("Dark Edge Obtained!");
              weaponDamage = 14;
              weaponEquipped = "Dark Edge";
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 3 && currentEnemyName == "Death Bear"){
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("Nothing lootable");
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 3 && currentEnemyName == "Knight"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 3);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 20);
          if(randNum == 10){
            WriteLine("The Knights deep black armor lays in the debris");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get Night Armor with armor + 6");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              WriteLine("Night Armor Obtained");
              armor = 6;
              armorEquipped = "Night Armor";
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }
      }else if(playerLevel == 4){
        if(playerLevel == 4 && currentEnemyName == "Large Moth"){
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("Nothing but a dead fuzzy moth");
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 4 && currentEnemyName == "Angry mob"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(2, 8);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 10);
          if(randNum == 5){
            WriteLine("The mobs Pitchfork lays on the floor");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get A Mob Pitchfork with damage + 7");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              WriteLine("Mob Pitchfork obtained");
              Damage = 7;
              weaponEquipped = "Mob Pitchfork";
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 4 && currentEnemyName == "Wizard"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(2, 10);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 4 && currentEnemyName == "HobGoblin"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 5);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 6);
          if(randNum == 3){
            WriteLine("A Sword lays on the battlefield");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get a Sword with 15 Damage");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              WriteLine("You obtained a Sword!");
              weaponDamage = 15;
              weaponEquipped = "Sword";
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }
      }else if(playerLevel == 5){
        if(playerLevel == 5 && currentEnemyName == "Ranger"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 10);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 15);
          if(randNum == 8){
            WriteLine("The Ranger's bow lays on the floor");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get Ranger's Bow with 14 Damage");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              WriteLine("Ranger's Bow Obtained!");
              weaponDamage = 14;
              weaponEquipped = "Ranger's Bow";
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 5 && currentEnemyName == "Posessed Spirit"){
          ForegroundColor = ConsoleColor.DarkYellow;
          WriteLine("The Spirit leaves nothing behind");
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 5 && currentEnemyName == "Evil Sprite"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 3);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }else if(playerLevel == 5 && currentEnemyName == "Evil Wizard"){
          ForegroundColor = ConsoleColor.DarkYellow;
          randNum = random.Next(1, 8);
          WriteLine("You gained " + randNum + " Gold!");
          gold += randNum;
          randNum = random.Next(1, 4);
          if(randNum == 2){
            WriteLine("The Wizard's spell caster is all that is left.");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get + 2 spell casts");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              WriteLine("You've gained 2 more spell casts");
              spellCasts += 2;
            }
          }
          randNum = random.Next(1, 100);
          if (randNum == 37)
          {
            WriteLine("The wizard leaves behind Cybotron armor.");
            WriteLine("[0] Leave it");
            WriteLine("[1] Take it");
            WriteLine("Get + 8 armor");
            keyInput = ReadKey();
            if (keyInput.KeyChar == '0')
            {
              LoadMainMenu();
            }
            else if (keyInput.KeyChar == '1')
            {
              WriteLine("You got armor 8");
              armorEquipped = "Cybotron";
              armor = 9;
            }
          }
          EnemyKills += 1;
          ReadKey();
          LoadMainMenu();
        }
      }else if(playerLevel == 5 && currentEnemyName  == "Soul of Bunnytoesia"){
        ForegroundColor = ConsoleColor.Green;
        LevelUp();
        WriteLine("The Soul Of Bunnytoesia shrivels to dust");
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Bunnytoesia is now safe...");
        ReadKey();
        Clear();
        WriteLine("...But, not for long.");
        ReadKey();
        LoadMainMenu();
      }
      }

      public static void Hospital(){
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Welcome to NorthWest " + LandName + " Hospital");
        ForegroundColor = ConsoleColor.Blue;
        WriteLine("Would you like to heal completely?");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[0] No");
        WriteLine("[1] Yes");
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Cost:5g");
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          LoadMainMenu();
        }else if(keyInput.KeyChar == '1'){
          if(gold < 5){
            WriteLine("\nNot Enough Gold.");
            ReadKey();
            Hospital();
          }else if(gold >= 5){
            Clear();
            WriteLine("Purchase successful!");
            ReadKey();
            PlayerHp = 100;
            gold -= 5;
            LoadMainMenu();
          }
        }else{
          Hospital();
        }
      }

      public static void LevelUp(){
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Welcome to the adventurers Guild!");
        if(playerLevel == 1){
          if(EnemyKills >= 10){
            ForegroundColor = ConsoleColor.Green;
            WriteLine("[0] leave");
            WriteLine("[1] Level Up");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("You have leveled Up to level 2!");
              playerLevel = 2;
              EnemyKills = 0;
              ReadKey();
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }else{
            ForegroundColor = ConsoleColor.Green;
            killsLeft = 10;
            killsLeft -= EnemyKills;
            WriteLine("[0] leave");
            WriteLine("need " + killsLeft + " more kills.");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }
        }else if(playerLevel == 2){
            if(EnemyKills >= 15){
            ForegroundColor = ConsoleColor.Green;
            WriteLine("[0] leave");
            WriteLine("[1] Level Up");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("You have leveled Up to level 3!");
              WriteLine("New Items in shops!");
              playerLevel = 3;
              EnemyKills = 0;
              ReadKey();
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }else{
            killsLeft = 15;
            ForegroundColor = ConsoleColor.Green;
            killsLeft -= EnemyKills;
            WriteLine("[0] leave");
            WriteLine("need " + killsLeft + " more kills.");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }
        }else if(playerLevel == 3){
            if(EnemyKills >= 20){
            ForegroundColor = ConsoleColor.Green;
            WriteLine("[0] leave");
            WriteLine("[1] Level Up");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("You have leveled Up to level 4!");
              playerLevel = 4;
              EnemyKills = 0;
              ReadKey();
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }else{
            killsLeft = 20;
            ForegroundColor = ConsoleColor.Green;
            killsLeft -= EnemyKills;
            WriteLine("[0] leave");
            WriteLine("need " + killsLeft + " more kills.");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }
        }else if(playerLevel == 4){
            if(EnemyKills >= 25){
            ForegroundColor = ConsoleColor.Green;
            WriteLine("[0] leave");
            WriteLine("[1] Level Up");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("You have leveled Up to level 5!");
              playerLevel = 5;
              EnemyKills = 0;
              ReadKey();
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }else{
            killsLeft = 25;
            ForegroundColor = ConsoleColor.Green;
            killsLeft -= EnemyKills;
            WriteLine("[0] leave");
            WriteLine("need " + killsLeft + " more kills.");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }
        }else if(playerLevel == 5){
            if(EnemyKills >= 30){
            ForegroundColor = ConsoleColor.Green;
            WriteLine("[0] leave");
            WriteLine("[1] Clear Bunnytoesia");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              Clear();
              WriteLine("You have cleared Bunnytoesia!");
              playerLevel = 5;
              EnemyKills = 0;
              ReadKey();
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }else{
            killsLeft = 30;
            ForegroundColor = ConsoleColor.Green;
            killsLeft -= EnemyKills;
            WriteLine("[0] leave");
            WriteLine("need " + killsLeft + " more kills.");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else{
              LevelUp();
            }
          }
        }else{
          if(EnemyKills >= 30){
            WriteLine("[0] Leave");
            WriteLine("[1] Clear Bunnytoesia!");
            keyInput = ReadKey();
            if(keyInput.KeyChar == '0'){
              LoadMainMenu();
            }else if(keyInput.KeyChar == '1'){
              WriteLine("Bunnytoesia have been cleared but one monster still remains...");
              ReadKey();
              isBossFighting = true;
              playerLevel = 6;
              EnterBunnytoesia();
            }
          }
        }
      }
      public static void Cheats(){
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("YOU HAVE ACCESSED THE CHEATS LOCATION.");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[0] leave");
        WriteLine("[1] get free money!");
        WriteLine("[2] skip a level!");
        WriteLine("[3] Heal for free!");
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          LoadMainMenu();
        }else if(keyInput.KeyChar == '1'){
          gold += 10;
          LoadMainMenu();
        }else if(keyInput.KeyChar == '2'){
          if(playerLevel < 5){
            playerLevel += 1;
          }else{
            WriteLine("\nMax Level!");
            ReadKey();
            LoadMainMenu();
          }
          LoadMainMenu();
        }else if(keyInput.KeyChar == '3'){
          PlayerHp = 100;
          LoadMainMenu();
        }
        if (keyInput.KeyChar == '%')
        {
          WriteLine("Enter password");
          string canYaGuessIt = ReadLine();
          if (canYaGuessIt == password)
          {
            ForegroundColor = ConsoleColor.Cyan;
            Clear();
            WriteLine("YOU GOT STACKED");
            Thread.Sleep(3000);
          
          
          spellCasts = 15;
          gold = 200;
        armorEquipped = "Cybotron armor";
        armor = 9;
        weaponEquipped = "Ranger Bow";
        weaponDamage = 14;
        spellEquipped = "Freeze";
        spellDamage = 15;
        LoadMainMenu();
          }
          if (canYaGuessIt == superPassword)
          {
            playerLevel = 6;
            LoadMainMenu();
          }
          else if (canYaGuessIt != superPassword && canYaGuessIt != password)
          {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("You got it wrong");
            Thread.Sleep(5000);
            LoadMainMenu();
          }
        }
        else{
          LoadMainMenu();
        }
      }

      public static void EnterTown(){
        Clear();
        Random rnd = new Random();
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"You enter the town and encounter the worst villian in all of {LandName}, the evil Dog Wizard");
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("[0] Leave");
        WriteLine("[1] Battle the boss");
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          LoadMainMenu();
        }
        if(keyInput.KeyChar == '1')
        {
          currentEnemyName = "Evil Dog Wizard";
          PlayerHp = 125;
          currentEnemyAttack = 16;
          CurrentEnemyHp = 130;
                  while(CurrentEnemyHp >= 1){
          Clear();
          WriteLine("Enemy Hp: " + CurrentEnemyHp);
          ForegroundColor = ConsoleColor.Green;
          if(currentEnemyName != "Soul Of Bunnytoesia" && currentEnemyName != "Evil Dog Wizard"){
            WriteLine("[0] evade");
          }
          WriteLine("[1] Attack with weapon");
          if(spellCasts >= 1 && spellEquipped != "NONE"){
            WriteLine("[2] Attack with spell");
          }
          keyInput = ReadKey();
          if(keyInput.KeyChar == '0'){
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("You evade, but not before it attacks you. You suffer " + currentEnemyAttack + "Damage");
            ReadKey();
            PlayerHp -= currentEnemyAttack;
            LoadMainMenu();
          }else if(keyInput.KeyChar == '1'){
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            if(currentEnemyName == "Evil Dog Wizard" && CurrentEnemyHp <= 50){
              WriteLine("The Evil Dog Wizard blocks some of your attack");
              randNum = rnd.Next(weaponDamage - 3, weaponDamage);
              WriteLine("The enemy takes " + randNum + " Damage"); 
            }else{
              randNum = rnd.Next(weaponDamage - 1, weaponDamage + 1);
              WriteLine("The enemy takes " + randNum + " Damage");
            }
            ReadKey();
            CurrentEnemyHp -= randNum;
          }else if(spellCasts >= 1){
            if(keyInput.KeyChar == '2'){
              Clear();
              ForegroundColor = ConsoleColor.Yellow;
              WriteLine("You use your spell against it. It takes " + spellDamage + "Damage");
              CurrentEnemyHp -= spellDamage;
              spellCasts -= 1;
              ReadKey();
            }
          }
          Clear();
          ForegroundColor = ConsoleColor.Red;
          Damage = currentEnemyAttack;
          Damage -= armor;
          PlayerHp -= Damage;
          WriteLine("The enemy attacks you dealing " + Damage + " Damage");
          WriteLine("You have " + PlayerHp + " HP left");
          if(PlayerHp <= 0){
            Death();
          }
          if (CurrentEnemyHp <= 0 && currentEnemyName == "Evil Dog Wizard")
          {
            WinGame();
          }
          ReadKey();
        }
        Clear();

        }
        else{
          EnterTown();
        }
      }
      public static void WinGame ()
      {
        WriteLine("You have beaten The Land of Bunnytoesia! Now check out some of my other projects https://replit.com/@Bunnytoes/MyWebsite#index.html");
      }
      public static void Death(){
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Bunnytoesia has taken your soul.");
        Environment.Exit(0);
       
      }
      public static void SaveLoad(){
        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[0] Leave");
        WriteLine("[1] Save");
        ForegroundColor = ConsoleColor.Red;
        WriteLine("DISCLAIMER: item names will not be saved via codes.(They will be renamed NONE)");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("[2] Load");
        keyInput = ReadKey();
        if(keyInput.KeyChar == '0'){
          LoadMainMenu();
        }else if(keyInput.KeyChar == '1'){
          saveGame();
        }else if(keyInput.KeyChar == '2'){
          LoadGame();
        }
      }
      public static void saveGame(){
        Clear();
        if(weaponDamage < 10){
          weaponDamageCode = "0" + weaponDamage.ToString();
        }else{
          weaponDamageCode = weaponDamage.ToString();
        }
        ArmorCode = armor.ToString();
        spellCastsCode = spellCasts.ToString();
        if(gold < 10){
          goldCode = "00" + gold.ToString();
        }else if(gold < 100 && gold > 9){
          goldCode = "0" + gold.ToString();
        }else if(gold < 1000 && gold > 99){
          goldCode = gold.ToString();
        }
        if(spellDamage < 10){
          spellDamageCode = "0" + spellDamage.ToString();
        }else{
          spellCastsCode = spellDamage.ToString();
        }
        LevelCode = playerLevel.ToString();
        codeOutput = weaponDamageCode + ArmorCode + spellCastsCode + goldCode + spellDamageCode + LevelCode;
        WriteLine("Copy this code by highlighting it right clicking and then copy:");
        WriteLine(codeOutput);
        ReadLine();
        LoadMainMenu();
      }
      public static void LoadGame(){
        Clear();
        WriteLine("Input your code. You wil have to type it in yourself(You can't paste on repls terminal)");
        string codeInput = ReadLine();
        string weapon = codeInput[0].ToString() + codeInput[1].ToString();
        string armors = codeInput[2].ToString();
        string spellCast = codeInput[3].ToString();
        string golds = codeInput[4].ToString() + codeInput[5].ToString() + codeInput[6].ToString();
        string spell = codeInput[7].ToString() + codeInput[8].ToString();
        string Ummmm = codeInput[9].ToString();
        weaponDamage = Int32.Parse(weapon);
        armor = Int32.Parse(armors);
        spellCasts = Int32.Parse(spellCast);
        gold = Int32.Parse(golds);
        spellDamage = Int32.Parse(spell);
        playerLevel = Int32.Parse(Ummmm);
        weaponEquipped = "NONE";
        spellEquipped = "NONE";
        armorEquipped = "NONE";
        Clear();
        WriteLine("Code successful!");
        ReadKey();
        LoadMainMenu();
      }
}

    
    
  
/* please don't cheat a lot, I put it in to be fun, not to ruin it */
