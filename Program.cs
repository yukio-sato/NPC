 // Int
int chance, rodadas, surpresa;
chance = 0;
rodadas = 0;
surpresa = 0;

 // String
string mensagem, inicio;
mensagem = "";
inicio = "Buscando";

 // Bool
bool machucado, inimigo;
machucado = false;
inimigo = false;

// rodadas
while (chance <= 2)
{     Console.ForegroundColor = ConsoleColor.Gray;
    rodadas++;
    if (mensagem != "" && mensagem != "Caído") {inicio = mensagem;}
if (inicio == "Buscando" && mensagem != "Caído" && (machucado == true || inimigo ==  false))
{chance = 0;}
else if ((inicio == "Buscando" || inicio == "Lutando") && mensagem != "Caído" && machucado ==  false && inimigo == true)
{ chance = 1;}
else if (inicio == "Lutando" && mensagem != "Caído" && inimigo == false)
{ chance = 0;}
else if (inicio == "Lutando" && mensagem != "Caído" && machucado == true)
{ chance = 2;}
else if (inicio == "Correndo" && mensagem != "Caído" && machucado == true)
{ chance = 2;}
else if (inicio == "Correndo" && mensagem != "Caído" && machucado == false)
{chance = 1;}
else
{chance = 3;}
    mensagem = chance switch
{
    0 => "Buscando",
    1 => "Lutando",
    2 => "Correndo",
    _ => "Caído"
};

// resultado
Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write($"{rodadas,2}# ");
    Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write($"[{inicio,-8}]: ");
    Console.ForegroundColor = ConsoleColor.Gray;
Console.Write($"Ferido = [{(machucado ? "S":"N")}], ");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write($"InimigoProximo = [{(inimigo ? "S":"N")}], ");
    Console.ForegroundColor = ConsoleColor.DarkRed;
Console.Write($"Eliminado = [{((mensagem=="Caído") ? "S":"N")}] ");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write($"=> [{mensagem,-8}]\n");


// "surpresas"
surpresa = new Random().Next(0,100);
switch (mensagem)
{
    case "Buscando":

if (surpresa > 49)
 {inimigo = true;}
 else if (surpresa <= 49 && machucado == true)
 {
    machucado = false;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n-- Se curou da condição: ");
     Console.WriteLine("Machucado --\n");
 }
    break;
    case "Lutando":

 if (surpresa > 49)
 {
    machucado = true;
        Console.BackgroundColor = ConsoleColor.DarkRed;
     Console.ForegroundColor = ConsoleColor.Gray;
     Console.Write("\n-- Esta com a condição: ");
                  Console.ForegroundColor = ConsoleColor.Red;
     Console.WriteLine("Machucado --\n");
     surpresa = new Random().Next(0,100);
 if (surpresa <= 50)
{
             inicio = mensagem;
    mensagem = "Caído";
            Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
    Console.Write("-- Morreu ");
    Console.Write("lutando ");
     Console.Write("com a condição: ");

     Console.WriteLine("Machucado --\n");
     }
 }
 else if (surpresa <= 49 && inimigo == true)
 {
    inimigo = false;
 }
    break;
    case "Correndo":
    if (surpresa <= 25 && machucado == true)
 {
         inicio = mensagem;
    mensagem = "Caído";
            Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
    Console.Write("-- Morreu ");
    Console.Write("correndo ");
    Console.Write("com a condição: ");
    Console.WriteLine("Machucado --\n");
      }
 else if (surpresa <= 50 && machucado == true)
 {
    machucado = false;
    Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n-- Se curou da condição: ");
     Console.WriteLine("Machucado --\n");
 }
  else if (surpresa > 50 && inimigo == true)
 {
    inimigo = false;
 }
    break;
}

Thread.Sleep(100);
}
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"\nO NPC ficou vivo durante ");
    Console.Write($"{rodadas-1} ");
    Console.WriteLine($"Rodadas");

Console.ResetColor();