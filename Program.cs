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
//buscando
if (mensagem == "Buscando")
{
 surpresa = new Random().Next(0,100);
 if (surpresa > 49)
 {
    inimigo = true;
 }
 else if (surpresa <= 49 && machucado == true)
 {
    machucado = false;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nSe curou da condição: Machucado\n");
 }
}
//lutando

else if (mensagem == "Lutando")
{
 surpresa = new Random().Next(0,100);
 if (surpresa > 49)
 {
    machucado = true;
     Console.ForegroundColor = ConsoleColor.Cyan;
     Console.WriteLine("\nEsta com a condição: Machucado\n");
     surpresa = new Random().Next(0,100);
 if (surpresa <= 50)
{
    mensagem = "Caído";
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Morreu lutando com a condição: Machucado\n");
}
 }
 else if (surpresa <= 49 && inimigo == true)
 {
    inimigo = false;
 }
}
//correndo

else if (mensagem == "Correndo")
{
 surpresa = new Random().Next(0,100);
 if (surpresa <= 25 && machucado == true)
 {
    mensagem = "Caído";
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Morreu correndo com a condição: Machucado\n");
 }
 else if (surpresa <= 50 && machucado == true)
 {
    machucado = false;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nSe curou da condição: Machucado\n");
 }
  else if (surpresa > 50 && inimigo == true)
 {
    inimigo = false;
 }
}
Thread.Sleep(1000);
}
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"\nO NPC ficou vivo durante ");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write($"{rodadas-1} ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"Rodadas");

Console.ResetColor();