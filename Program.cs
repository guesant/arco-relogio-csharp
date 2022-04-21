void MostrarInformacoes()
{
  Console.WriteLine(@"
============================================
- Licensa: GPL-3.0
- Autor: Gabriel R. Antunes (a.k.a. @guesant)

- Histórico de versões:
  - v0.0.1 - 2022-03-08
  - v0.0.2 - 2022-04-19
============================================
".Trim());
}

double PonteiroHoraParaAngulo(double hora)
{
  // 12h - 360º
  //  1h -  30º
  return hora * 30;
}

double PonteiroMinutoParaAngulo(double minuto)
{
  // 60min - 360º
  //  1min -   6º
  return minuto * 6;
}

double CalcularAnguloComplementar(double angulo)
{
  return (360 - angulo);
}

double CalcularArcoMenor(double anguloQualquer)
{
  if (anguloQualquer <= 180)
  {
    return anguloQualquer;
  }
  return CalcularAnguloComplementar(anguloQualquer);
}

double CalcularArcoMaior(double anguloQualquer)
{
  if (anguloQualquer >= 180)
  {
    return anguloQualquer;
  }
  return CalcularAnguloComplementar(anguloQualquer);
}

string FormatarHora(uint hora, uint minuto)
{
  return $"{Convert.ToString(hora).PadLeft(2, '0')}h{Convert.ToString(minuto).PadLeft(2, '0')}";
}

(double anguloArcoMenor, double anguloArcoMaior) CalcularArcosEntreOsPonteiros(uint _hora, uint _minuto)
{
  var hora = _hora % 12;

  var minuto = _minuto % 60;

  // ângulo formado pelo ponteiro da hora (considerando 0h como a origem)
  var anguloPonteiroHora = PonteiroHoraParaAngulo(hora + (minuto / 60D));

  // ângulo formado pelo ponteiro do minuto (considerando 0min como a origem)
  var anguloPonteiroMinuto = PonteiroMinutoParaAngulo(minuto);

  // ângulo de um arco qualquer, não sabemos se esse arco é o maior ou o menor
  // estou usando o Math.Abs para conseguir o número absoluto, ou seja, "para tirar o sinal de negativo".
  var anguloArcoQualquer = Math.Abs(anguloPonteiroMinuto - anguloPonteiroHora);

  var anguloArcoMenor = CalcularArcoMenor(anguloArcoQualquer);

  var anguloArcoMaior = CalcularArcoMaior(anguloArcoQualquer);

  return (anguloArcoMenor, anguloArcoMaior);
}

void MostrarArcosEntreOsPonteiros(uint _hora, uint _minuto)
{
  var hora = _hora % 24;
  var minuto = _minuto % 60;

  (double anguloArcoMenor, double anguloArcoMaior) = CalcularArcosEntreOsPonteiros(hora, minuto);

  Console.WriteLine($"Às {FormatarHora(hora, minuto)}, temos os seguintes arcos:");
  Console.WriteLine($"  - o arco menor mede {anguloArcoMenor}º.");
  Console.WriteLine($"  - o arco maior mede {anguloArcoMaior}º.");
}

MostrarInformacoes();

while (true)
{
  Console.Write("> Digite a hora: ");
  uint hora = Convert.ToUInt32(Console.ReadLine());

  Console.Write("> Digite o minuto: ");
  uint minuto = Convert.ToUInt32(Console.ReadLine());

  Console.WriteLine("----------------------------------------");

  MostrarArcosEntreOsPonteiros(hora, minuto);

  Console.WriteLine("----------------------------------------");

  Console.ReadKey();

  Console.Write("Deseja consultar mais algum arco? [sim/NAO]: ");

  if (Console.ReadLine()!.ToLower() != "sim")
  {
    break;
  }

  Console.Clear();
}

Console.WriteLine("Fim.");
