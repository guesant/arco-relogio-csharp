void MostrarInformacoes() {
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

double PonteiroHoraParaAngulo(double hora) {
  // 12h - 360º
  //  1h -  30º
  return hora * 30;
}

double PonteiroMinutoParaAngulo(double minuto) {
  // 60min - 360º
  //  1min -   6º
  return minuto * 6;
}

double CalcularAnguloComplementar(double angulo) {
  return (360 - angulo);
}

double CalcularArcoMenor(double anguloQualquer) {
  if(anguloQualquer < 180) {
    return anguloQualquer;
  }
  return CalcularAnguloComplementar(anguloQualquer);
}

double CalcularArcoMaior(double anguloQualquer) {
  if(anguloQualquer > 180) {
    return anguloQualquer;
  }
  return CalcularAnguloComplementar(anguloQualquer);
}

void CalcularArcosEntreOsPonteiros(uint _hora, uint _minuto) {
  var hora = _hora % 24;
  var minuto = _minuto % 60;

  // ângulo formado pelo ponteiro da hora (a partir das 0h)
  var anguloPonteiroHora = PonteiroHoraParaAngulo(hora + ((double)minuto/60));

  // ângulo formado pelo ponteiro do minuto (a partir do 0min)
  var anguloPonteiroMinuto = PonteiroMinutoParaAngulo(minuto);
  
  // ângulo de um arco qualquer, não sabemos se esse arco é o maior ou o menor
  // estou usando o Math.Abs para conseguir o número absoluto, ou seja, "para tirar o sinal de negativo".
  var arcoQualquerAngulo = Math.Abs(anguloPonteiroMinuto - anguloPonteiroHora) % 360;
  
  var dataFormatada = $"{Convert.ToString(hora).PadLeft(2, '0')}h{Convert.ToString(minuto).PadLeft(2, '0')}";

  Console.WriteLine($"Às {dataFormatada}, temos os seguintes arcos:");
  Console.WriteLine($"  - o arco menor mede {CalcularArcoMenor(arcoQualquerAngulo)}º.");
  Console.WriteLine($"  - o arco maior mede {CalcularArcoMaior(arcoQualquerAngulo)}º.");
}

MostrarInformacoes();

while(true) {
  Console.Write("> Digite a hora: ");
  uint hora = Convert.ToUInt32(Console.ReadLine());
  
  Console.Write("> Digite o minuto: ");
  uint minuto = Convert.ToUInt32(Console.ReadLine());
  
  Console.WriteLine("----------------------------------------");

  CalcularArcosEntreOsPonteiros(hora, minuto);
  
  Console.WriteLine("----------------------------------------");

  Console.ReadKey();
  
  Console.Write("Deseja consultar mais algum arco? [sim/NAO]: ");

  if(Console.ReadLine()!.ToLower() != "sim") {
    break;
  }

  Console.Clear();

}

Console.WriteLine("Fim.");
