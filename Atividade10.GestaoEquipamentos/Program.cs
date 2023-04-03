using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Atividade10.GestaoEquipamentos
{
     internal class Program
     {
          static void Main(string[] args)
          {
               ArrayList listaNomeEquipamentos = new ArrayList();
               ArrayList listaPrecoEquipamentos = new ArrayList();
               ArrayList listaSerieEquipamentos = new ArrayList();
               ArrayList listaDataEquipamentos = new ArrayList();
               ArrayList listaFabricanteEquipamentos = new ArrayList();

               ArrayList listaTituloChamados = new ArrayList();
               ArrayList listaDescricaoChamados = new ArrayList();
               ArrayList listaEquipamentoChamados = new ArrayList();
               ArrayList listaDataChamados = new ArrayList();
               ArrayList listaAberturaChamados = new ArrayList();

               bool saidaPrograma = false;
               bool saidaEquipamento = false;
               bool saidaChamados = false;

               do
               {
                    saidaEquipamento = false;
                    saidaChamados = false;

                    ImprimirMenus("geral", "");

                    string opcaoGeral = PegarValor("\nEntre com uma opção:\n> ");

                    switch (opcaoGeral)
                    {
                         case "1":

                              do
                              {
                                   ImprimirMenus("equipamentos", "");

                                   string opcaoEquipamentos = PegarValor("\nEntre com uma opção:\n> ");

                                   switch (opcaoEquipamentos)
                                   {
                                        case "1":

                                             ImprimirMensagem("Registrando Equipamento...", "inicializando");
                                             AdquirirNomeEquipamento(listaNomeEquipamentos, 6, "", 0);
                                             AdquirirPrecoEquipamento(listaPrecoEquipamentos, "", 0);
                                             AdquirirSerieEquipamento(listaSerieEquipamentos, "", 0);
                                             AdquirirDataEquipamento(listaDataEquipamentos, "", 0);
                                             AdquirirFabricanteEquipamento(listaFabricanteEquipamentos, "", 0);
                                             ImprimirMensagem("Equipamento Registrado com Sucesso!", " ");

                                             break;

                                        case "2":

                                             ImprimirMensagem("Mostrando Equipamentos...", "inicializando");
                                             VisualizarEquipamentos(listaNomeEquipamentos, listaPrecoEquipamentos, listaSerieEquipamentos, listaDataEquipamentos, listaFabricanteEquipamentos);
                                             Console.ReadLine();

                                             break;

                                        case "3":

                                             ImprimirMensagem("Editando Equipamento...", "inicializando");
                                             VisualizarEquipamentos(listaNomeEquipamentos, listaPrecoEquipamentos, listaSerieEquipamentos, listaDataEquipamentos, listaFabricanteEquipamentos);
                                             int numeroSerie = Convert.ToInt32(PegarValor("\n\nEntre com o número de série do equipamento:\n> "));

                                             if (listaSerieEquipamentos.Contains(numeroSerie))
                                             {
                                                  int indexDaSerie = listaSerieEquipamentos.IndexOf(numeroSerie);
                                                  Console.WriteLine();

                                                  AdquirirNomeEquipamento(listaNomeEquipamentos, 6, "novo ", indexDaSerie);

                                                  AdquirirPrecoEquipamento(listaPrecoEquipamentos, "novo ", indexDaSerie);

                                                  AdquirirDataEquipamento(listaDataEquipamentos, "novo ", indexDaSerie);

                                                  AdquirirFabricanteEquipamento(listaFabricanteEquipamentos, "novo ", indexDaSerie);

                                                  ImprimirMensagem("Equipamento Atualizado com Sucesso!", " ");
                                             }

                                             else
                                             {
                                                  ImprimirMensagem("\nEntre com um número de série válido!", "erro");
                                             }

                                             break;

                                        case "4":

                                             ImprimirMensagem("Removendo Equipamento...", "inicializando");
                                             VisualizarEquipamentos(listaNomeEquipamentos, listaPrecoEquipamentos, listaSerieEquipamentos, listaDataEquipamentos, listaFabricanteEquipamentos);
                                             numeroSerie = Convert.ToInt32(PegarValor("\n\nEntre com o número de série do equipamento:\n> "));

                                             if (listaSerieEquipamentos.Contains(numeroSerie))
                                             {
                                                  int indexDaSerie = listaSerieEquipamentos.IndexOf(numeroSerie);
                                                  Console.WriteLine();
                                                  RemoverItensEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaSerieEquipamentos, listaDataEquipamentos, listaFabricanteEquipamentos, indexDaSerie);
                                                  ImprimirMensagem("Equipamento Removido com Sucesso!", " ");
                                             }

                                             else
                                             {
                                                  ImprimirMensagem("\nEntre com um número de série válido!", "erro");
                                             }

                                             break;

                                        case "0":

                                             ImprimirMenus("saindo", "Saindo para o menu...");
                                             saidaEquipamento = true;
                                             break;

                                        default:

                                             ImprimirMenus("nada", "");
                                             break;
                                   }

                              } while (saidaEquipamento == false);

                              break;

                         case "2":

                              do
                              {
                                   ImprimirMenus("chamados", "");
                                   Console.WriteLine();
                                   string opcaoChamados = PegarValor("\nEntre com uma opção:\n> ");

                                   switch (opcaoChamados)
                                   {

                                        case "1":

                                             bool serieInvalida = false;

                                             ImprimirMensagem("Registrando Chamado...", "inicializando");

                                             AdquirirTituloChamado(listaTituloChamados, "", 0);

                                             AdquirirDescricaoChamado(listaDescricaoChamados, "", 0);

                                             int equipamentoChamado = (Convert.ToInt32(PegarValor("\nEntre com a série do equipamento para o chamado:\n> ")));

                                             if (listaSerieEquipamentos.Contains(equipamentoChamado))
                                             {
                                                  int index = listaSerieEquipamentos.IndexOf(equipamentoChamado);
                                                  string nome = Convert.ToString(listaNomeEquipamentos[index]);
                                                  listaEquipamentoChamados.Add(nome);
                                             }
                                             else
                                             {
                                                  ImprimirMensagem("Entre com um número de série válido!", "erro");
                                                  serieInvalida = true;
                                             }

                                             if (serieInvalida == true)
                                             {
                                                  break;
                                             }

                                             AdquirirDataChamado(listaDataChamados, listaAberturaChamados, "", 0);

                                             ImprimirMensagem("Chamado Registrado com Sucesso!", "");

                                             break;

                                        case "2":

                                             VisualizarChamados(listaTituloChamados, listaEquipamentoChamados, listaDataChamados, listaAberturaChamados);
                                             Console.ReadLine();

                                             break;

                                        case "3":
                                             bool serie = false;
                                             ImprimirMensagem("Editando Chamado...", "inicializando");
                                             VisualizarChamados(listaTituloChamados, listaEquipamentoChamados, listaDataChamados, listaAberturaChamados);

                                             int numeroLinha = Convert.ToInt32(PegarValor("\n\nEntre com o número da linha que deseja editar:\n> "));
                                             Console.WriteLine();
                                             if (numeroLinha < listaTituloChamados.Count)
                                             {
                                                  AdquirirTituloChamado(listaTituloChamados, "novo ", numeroLinha);

                                                  AdquirirDescricaoChamado(listaDescricaoChamados, "novo ", numeroLinha);

                                                  equipamentoChamado = (Convert.ToInt32(PegarValor("\nEntre com a série do equipamento para o novo chamado:\n> ")));

                                                  if (listaSerieEquipamentos.Contains(equipamentoChamado))
                                                  {
                                                       int index = listaSerieEquipamentos.IndexOf(equipamentoChamado);
                                                       string nome = Convert.ToString(listaNomeEquipamentos[index]);
                                                       listaEquipamentoChamados.Add(nome);
                                                  }
                                                  else
                                                  {
                                                       ImprimirMensagem("Entre com um número de série válido!", "erro");
                                                       serie = true;
                                                  }

                                                  if (serie == true)
                                                  {
                                                       break;
                                                  }

                                                  AdquirirDataChamado(listaDataChamados, listaAberturaChamados, "novo ", numeroLinha);

                                                  ImprimirMensagem("Chamado Atualizado com Sucesso!", "");
                                             }

                                             else
                                             {
                                                  ImprimirMensagem("\nEntre com um número de linha válido!", "erro");
                                             }

                                             break;

                                        case "4":

                                             ImprimirMensagem("Removendo Chamado...", "inicializando");

                                             VisualizarChamados(listaTituloChamados, listaEquipamentoChamados, listaDataChamados, listaAberturaChamados);

                                             numeroLinha = Convert.ToInt32(PegarValor("\n\nEntre com o número de linha do chamado:\n> "));

                                             if (numeroLinha < listaTituloChamados.Count)
                                             {
                                                  RemoverItensChamado(listaTituloChamados, listaDescricaoChamados, listaEquipamentoChamados, listaDataChamados, listaAberturaChamados, numeroLinha);
                                                  ImprimirMensagem("Equipamento Removido com Sucesso!", " ");
                                             }

                                             else
                                             {
                                                  ImprimirMensagem("\nEntre com um número de linha válido!", "erro");
                                             }

                                             break;

                                        case "0":

                                             ImprimirMenus("saindo", "Saindo para o menu...");
                                             saidaChamados = true;
                                             break;

                                        default:

                                             ImprimirMenus("nada", "");
                                             break;
                                   }

                              } while (saidaChamados == false);

                              break;

                         case "0":

                              ImprimirMenus("saindo", "Saindo do programa...");
                              saidaPrograma = true;
                              break;

                         default:

                              ImprimirMenus("nada", "");
                              break;
                    }

               } while (saidaPrograma == false);
          }

          private static void RemoverItensChamado(ArrayList listaTituloChamados, ArrayList listaDescricaoChamados, ArrayList listaEquipamentoChamados, ArrayList listaDataChamados, ArrayList listaAberturaChamados, int numeroLinha)
          {
               listaTituloChamados.RemoveAt(numeroLinha);
               listaEquipamentoChamados.RemoveAt(numeroLinha);
               listaDescricaoChamados.RemoveAt(numeroLinha);
               listaDataChamados.RemoveAt(numeroLinha);
               listaAberturaChamados.RemoveAt(numeroLinha);
          }

          private static void VisualizarChamados(ArrayList listaTituloChamados, ArrayList listaEquipamentoChamados, ArrayList listaDataChamados, ArrayList listaAberturaChamados)
          {
               Console.Clear();
               Console.ForegroundColor = ConsoleColor.DarkCyan;
               Console.Write("----------------------------------------------------------------------------------------------------");
               Console.WriteLine(string.Format("\n| {0,-5} | {1,-20} | {2,-25} | {3,-10} | {4,-20} | ", "LINHAS", "TÍTULO", "EQUIPAMENTO", "DATA ABERTURA", "DIAS QUE ESTÁ ABERTO"));
               Console.WriteLine("----------------------------------------------------------------------------------------------------");
               Console.ResetColor();
               Console.WriteLine();

               for (int i = 0; i < listaTituloChamados.Count; i++)
               {
                    Console.WriteLine(string.Format("| {0,-6} | {1,-20} | {2,-25} | {3,-13} | {4,-20} | ", i, listaTituloChamados[i], listaEquipamentoChamados[i], listaDataChamados[i], listaAberturaChamados[i]));
               }
          }

          private static void AdquirirDataChamado(ArrayList listaDataChamados, ArrayList listaAberturaChamados, string chamadoNovo, int index)
          {
               DateTime dataChamado = (Convert.ToDateTime(PegarValor($"\nEntre com a data de abertura do {chamadoNovo}chamado (/ ou -):\n> ")));
               var dataFormatada = String.Format("{0:dd/MM/yyyy}", dataChamado);
               DateTime dataAberta = DateTime.Now;
               TimeSpan diasAberto = dataAberta.Subtract(dataChamado);
               var dataAberturaFormatada = String.Format("{0:dd}", diasAberto);

               if (chamadoNovo == "novo ")
               {
                    listaAberturaChamados[index] = (dataAberturaFormatada);
                    listaDataChamados[index] = (dataFormatada);
               }
               else
               {
                    listaAberturaChamados.Add(dataAberturaFormatada);
                    listaDataChamados.Add(dataFormatada);
               }

          }

          private static void AdquirirDescricaoChamado(ArrayList listaDescricaoChamados, string chamadoNovo, int index)
          {
               string descricaoChamado = (PegarValor($"\nEntre com a descrição do {chamadoNovo}chamado:\n> "));

               if (chamadoNovo == "novo ")
               {
                    listaDescricaoChamados[index] = descricaoChamado;
               }
               else
               {
                    listaDescricaoChamados.Add(descricaoChamado);
               }
          }

          private static void AdquirirTituloChamado(ArrayList listaTituloChamados, string chamadoNovo, int index)
          {
               string tituloChamado = (PegarValor($"Entre com o título do {chamadoNovo}chamado:\n> "));
               if (chamadoNovo == "novo ")
               {
                    listaTituloChamados[index] = tituloChamado;
               }

               else
               {
                    listaTituloChamados.Add(tituloChamado);
               }

          }

          private static void RemoverItensEquipamento(ArrayList listaNomeEquipamentos, ArrayList listaPrecoEquipamentos, ArrayList listaSerieEquipamentos, ArrayList listaDataEquipamentos, ArrayList listaFabricanteEquipamentos, int indexDaSerie)
          {

               listaNomeEquipamentos.RemoveAt(indexDaSerie);
               listaPrecoEquipamentos.RemoveAt(indexDaSerie);
               listaSerieEquipamentos.RemoveAt(indexDaSerie);
               listaFabricanteEquipamentos.RemoveAt(indexDaSerie);
               listaDataEquipamentos.RemoveAt(indexDaSerie);

          }

          private static void VisualizarEquipamentos(ArrayList listaNomeEquipamentos, ArrayList listaPrecoEquipamentos, ArrayList listaSerieEquipamentos, ArrayList listaDataEquipamentos, ArrayList listaFabricanteEquipamentos)
          {
               Console.ForegroundColor = ConsoleColor.DarkCyan;
               Console.Write("-------------------------------------------------------------------------------------------");
               Console.WriteLine(string.Format("\n| {0,-10} | {1,-25} | {2,-10} | {3,-20} | {4,-10} |", "ID", "NOME", "PREÇO", "FABRICANTE", "DATA"));
               Console.WriteLine("-------------------------------------------------------------------------------------------");
               Console.ResetColor();
               Console.WriteLine();

               for (int i = 0; i < listaSerieEquipamentos.Count; i++)
               {
                    Console.WriteLine(string.Format("| {0,-10} | {1,-25} | R${2,-8} | {3,-20} | {4,-10} |", listaSerieEquipamentos[i], listaNomeEquipamentos[i], listaPrecoEquipamentos[i], listaFabricanteEquipamentos[i], listaDataEquipamentos[i]));
               }
          }

          private static void AdquirirFabricanteEquipamento(ArrayList listaFabricanteEquipamentos, string equipamentoNovo, int index)
          {
               string fabricanteEquipamento = (PegarValor($"\nEntre com o nome da fabricante do {equipamentoNovo}equipamento:\n> "));

               if (equipamentoNovo == "novo ")
               {
                    listaFabricanteEquipamentos[index] = (fabricanteEquipamento);
               }
               else
               {
                    listaFabricanteEquipamentos.Add(fabricanteEquipamento);
               }

          }

          private static void AdquirirDataEquipamento(ArrayList listaDataEquipamentos, string equipamentoNovo, int index)
          {
               DateTime dataEquipamento = Convert.ToDateTime(PegarValor($"\nEntre com a data de fabricação do {equipamentoNovo}equipamento (separada por / ou -):\n> "));
               var dataFormatada = String.Format("{0:dd/MM/yyyy}", dataEquipamento);

               if (equipamentoNovo == "novo ")
               {
                    listaDataEquipamentos[index] = (dataFormatada);
               }
               else
               {
                    listaDataEquipamentos.Add(dataFormatada);
               }

          }

          private static void AdquirirSerieEquipamento(ArrayList listaSerieEquipamentos, string equipamentoNovo, int index)
          {
               int serieEquipamento = (Convert.ToInt32(PegarValor($"\nEntre com o número de série do {equipamentoNovo}equipamento:\n> ")));

               while (listaSerieEquipamentos.Contains(serieEquipamento))
               {
                    ImprimirMensagem("\nNúmero de série já existe!", "erro");
                    serieEquipamento = (Convert.ToInt32(PegarValor("Entre com o número de série do equipamento:\n> ")));
               }

               if (equipamentoNovo == "novo ")
               {
                    listaSerieEquipamentos[index] = (serieEquipamento);
               }
               else
               {
                    listaSerieEquipamentos.Add(serieEquipamento);
               }
          }

          private static void AdquirirPrecoEquipamento(ArrayList listaPrecoEquipamentos, string equipamentoNovo, int index)
          {
               decimal valorEquipamento = (Convert.ToDecimal(PegarValor($"\nEntre com o preço de aquisição do {equipamentoNovo}equipamento:\n> ")));
               valorEquipamento = Math.Round(valorEquipamento, 2);

               if (equipamentoNovo == "novo ")
               {
                    listaPrecoEquipamentos[index] = (valorEquipamento);
               }
               else
               {
                    listaPrecoEquipamentos.Add(valorEquipamento);
               }
          }

          private static void AdquirirNomeEquipamento(ArrayList listaNomeEquipamentos, int tamanho, string equipamentoNovo, int index)
          {
               string nomeEquipamento;
               nomeEquipamento = (PegarValor($"Entre com o nome do {equipamentoNovo}equipamento (mínimo 6 caracteres):\n> "));

               while (nomeEquipamento.Length < tamanho)
               {
                    ImprimirMensagem("\nNome com tamanho mínimo inválido!", "erro");
                    nomeEquipamento = (PegarValor("Entre com o nome do equipamento (mínimo 6 caracteres):\n> "));
               }
               if (equipamentoNovo == "novo ")
               {
                    listaNomeEquipamentos[index] = (nomeEquipamento);
               }
               else
               {
                    listaNomeEquipamentos.Add(nomeEquipamento);
               }
          }

          private static void ImprimirMenus(string tag, string mensagem)
          {
               string funcoes = "\n[1] Criar;\n[2] Visualizar;\n[3] Atualizar;\n[4] Deletar;\n[0] Sair.";

               if (tag == "geral")
               {
                    Console.Clear();
                    Console.WriteLine("|Gestão De Equipamentos|");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n[1] Equipamentos;\n[2] Chamados; \n[0] Sair.");
                    Console.ResetColor();
               }

               else if (tag == "equipamentos")
               {
                    Console.Clear();
                    Console.WriteLine("|Equipamentos|");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(funcoes);
                    Console.ResetColor();
               }

               else if (tag == "chamados")
               {
                    Console.Clear();
                    Console.WriteLine("|Chamados|");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(funcoes);
                    Console.ResetColor();
               }

               else if (tag == "saindo")
               {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                    Console.ReadLine();
               }

               else
               {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite uma opção válida!");
                    Console.ResetColor();
                    Console.ReadLine();
               }

          }

          private static string PegarValor(string mensagem)
          {
               Console.Write(mensagem);
               string valor = Console.ReadLine();
               return valor;
          }

          private static void ImprimirMensagem(string mensagem, string tipo)
          {
               if (tipo == "erro")
               {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
               }
               else if (tipo == "inicializando")
               {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                    Console.WriteLine();
               }
               else
               {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                    Console.ReadLine();
               }
          }
     }
}