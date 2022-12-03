 // Int
int chance, rodadas, surpresa, velocidade, porcentagem;
chance = 0; rodadas = 0; surpresa = 0; porcentagem = 50;

 // String
string mensagem, inicio;
mensagem = ""; inicio = "Buscando";

 // Bool
bool machucado, inimigo;
machucado = false; inimigo = false;

// rodadas
Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("- - - - Projeto: NPC - - - -");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("Escolha a dificuldade do jogo: ");
 Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Aleatório_[0]");
 Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Fácil_____[1]");
 Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Médio_____[2]");
 Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Difícil___[3]");
Console.ForegroundColor = ConsoleColor.Gray;
lvl(Convert.ToInt32(Console.ReadLine()!));
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Pressione uma tecla para continuar -");
Console.ReadKey();

Console.Clear();
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("Escolha a velocidade de estado por rodada: ");
 Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Devagar_____[0]");
 Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Normal______[1]");
 Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Acelerado___[2]");
 Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Instantâneo_[3]");
Console.ForegroundColor = ConsoleColor.Gray;
velocidade = Convert.ToInt32(Console.ReadLine()!);
speed(velocidade);
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Pressione uma tecla para continuar -");
Console.ReadKey();
Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("- Pressione uma tecla para começar -");
Console.ReadKey();
Console.Clear();

while (chance <= 2)
{
Console.ForegroundColor = ConsoleColor.Gray;
rodadas++;

if (mensagem != "" && mensagem != "Caído") 
{inicio = mensagem;}

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

if (surpresa > porcentagem)
 {inimigo = true;}

 else if (surpresa <= porcentagem && machucado == true)
 {estado("Curou","-- Se curou da condição: Machucado --\n");}
break;

case "Lutando":

 if (surpresa > porcentagem)
 {estado("Ferido","-- Esta com a condição: Machucado --\n");
surpresa = new Random().Next(0,100);

 if (surpresa <= porcentagem)
{estado("Morto","-- Morreu com a condição: Machucado --\n");}}

 else if (surpresa <= porcentagem && inimigo == true)
 {inimigo = false;}
break;

case "Correndo":

if (surpresa <= (porcentagem/2) && machucado == true)

 {estado("Morto","-- Morreu com a condição: Machucado --\n");}

 else if (surpresa <= porcentagem && machucado == true)
 {estado("Curou","-- Se curou da condição: Machucado --\n");}

  else if (surpresa > porcentagem && inimigo == true)
 {inimigo = false;}
break;
}

Thread.Sleep(velocidade+25);
}

// Duração do NPC ao decorrer das situações

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;
Console.Write($"\nO NPC ficou vivo durante {rodadas-1} Rodadas\n");
Console.ResetColor();

void estado (string atual, string frase)
{
if (atual == "Curou")
{
    machucado = false;
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.ForegroundColor = ConsoleColor.Green;
}
else if (atual == "Ferido")
{
    machucado = true;
    Console.BackgroundColor = ConsoleColor.DarkRed;
     Console.ForegroundColor = ConsoleColor.Gray;
}
else if (atual == "Morto")
{
    inicio = mensagem;
    mensagem = "Caído";
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;
}
    Console.Write(frase);

}
void lvl (int x)
{
    string level = "";

    if (x == 0)
    {lvl(new Random().Next(1,4));}

    else if (x == 1)
    {level = "Fácil";
    porcentagem = 75;
    Console.ForegroundColor = ConsoleColor.Green;}

    else if (x == 2)
    {level = "Médio";
    porcentagem = 50;
    Console.ForegroundColor = ConsoleColor.DarkCyan;}

    else if (x == 3)
    {level = "Difícil";
    porcentagem = 25;
    Console.ForegroundColor = ConsoleColor.Red;}
    if (x != 0)
Console.WriteLine($"Sua dificuldade é {level} [{x}].");
}
void speed (int a)
{
    string spd = "";

    if (a == 0)
   {spd = "Devagar";
    velocidade = 200;
    Console.ForegroundColor = ConsoleColor.Cyan;}

    else if (a == 1)
    {spd = "Normal";
    velocidade = 125;
    Console.ForegroundColor = ConsoleColor.Blue;}

    else if (a == 2)
    {spd = "Acelerado";
    velocidade = 30;
    Console.ForegroundColor = ConsoleColor.DarkGray;}

    else if (a == 3)
    {spd = "Instantâneo";
    velocidade = -25;
    Console.ForegroundColor = ConsoleColor.White;}

Console.WriteLine($"Sua velocidade é {spd} [{a}].");
}