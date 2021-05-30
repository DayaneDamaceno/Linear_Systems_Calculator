using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistemas_Lineares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtNumVariaveis.Value = 4;
        }

        double[,] sistema;
        double[,] matrizAumentada;
        double[] termosIndependentes;
        double[] termosIndependentesIniciais;
        int numVariaveis = 4;
        double resultado = 0;
        double[] x;

        private void txtNumVariaveis_ValueChanged(object sender, EventArgs e)
        {
            gridSistema.Columns.Clear();

            numVariaveis = int.Parse(txtNumVariaveis.Value.ToString());

            for (int i = 0; i < numVariaveis; i++)
            {
                gridSistema.Columns.Add($"colX{i + 1}", $"X{i + 1}");
                gridSistema.Rows.Add();
            }
            gridSistema.Columns.Add("colRes", "R");
            gridSistema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            
            txtNumVariaveis.Value = 4;
            numVariaveis = 4;
            sistema = new double[4, 4] { { 2, 2, 3, 14 }, { 5, 3, 8, 2 }, { 1, 4, 4, 2 }, { 4, 2, 9, 3 } };
            termosIndependentes = new double[4] { 12, 23, 50, 15 };

            for (int linha = 0; linha < 4; linha++)
            {
                for (int coluna = 0; coluna < 5; coluna++)
                {
                    if (coluna == numVariaveis)
                        gridSistema.Rows[linha].Cells[coluna].Value = termosIndependentes[linha];
                    else
                        gridSistema.Rows[linha].Cells[coluna].Value = sistema[linha, coluna];
                }

            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            openFileDialog1.FileName = "sistemas.txt";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Arquivos texto|*.txt";

            string[] linhas;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linhas = File.ReadAllLines(openFileDialog1.FileName);

                LerSistemaImportado(linhas);
             
            }
        }

        private void btnCalcularSistema_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";

            sistema = new double[numVariaveis, numVariaveis];
            matrizAumentada = new double[numVariaveis, numVariaveis];
            termosIndependentes = new double[numVariaveis];
            termosIndependentesIniciais = new double[numVariaveis];
            x = new double[numVariaveis];

            if (LerSistema())
                CalcularSistema();
            
        }

        /// <summary>
        /// Calcula o determinante de uma matriz 2x2
        /// </summary>
        /// <param name="a">Valor [0,0]</param>
        /// <param name="b">Valor [1,0]</param>
        /// <param name="c">Valor [0,1]</param>
        /// <param name="d">Valor [1,1]</param>
        /// <returns>O resultado do determinante</returns>
        double CalcularDeterminante(double a, double b, double c, double d)
        {
            return (a * d) - (b * c);
        }

        /// <summary>
        /// Zerar os coeficientes do sistema
        /// </summary>
        void EscalonarSistema()
        {
            for (int k = 0; k < (numVariaveis - 1); k++)
            {
                for (int i = (k + 1); i < numVariaveis; i++)
                {
                    for (int j = (k + 1); j < numVariaveis; j++)
                    {
                        sistema[i, j] = CalcularDeterminante(sistema[k, k], sistema[i, k], sistema[k, j], sistema[i, j]);
                    }
                    termosIndependentes[i] = CalcularDeterminante(sistema[k, k], sistema[i, k], termosIndependentes[k], termosIndependentes[i]);
                    sistema[i, k] = 0;
                }
                WriteSistema($"Matriz equivalente para X{k + 1}");
            }
        }

        /// <summary>
        /// Acha todas as incognitas do sistema
        /// </summary>
        void ResolverSistema()
        {
            if (sistema[numVariaveis - 1, numVariaveis - 1] != 0)
            {
                x[numVariaveis - 1] = termosIndependentes[numVariaveis - 1] / sistema[numVariaveis - 1, numVariaveis - 1];

                txtResultado.Text += "\r\n ----- Raizes ----- \r\n";
                txtResultado.Text += $"X{numVariaveis} = {Math.Round(x[numVariaveis - 1], 3)}\r\n";

                for (int k = numVariaveis - 2; k >= 0; k--)
                {
                    resultado = 0;

                    for (int j = k + 1; j < numVariaveis; j++)
                        resultado += sistema[k, j] * x[j];

                    x[k] = (termosIndependentes[k] - resultado) / sistema[k, k];

                    txtResultado.Text += $"X{k + 1} = {Math.Round(x[k], 3)}\r\n";
                }
                ProvaReal();
            }
            else
            {
                ShowError("Sistema invalido, não existe solução");
                txtResultado.Text = "";
                return;
            }

        }

        /// <summary>
        /// Verifica se as incognitas batem com o sistema
        /// </summary>
        void ProvaReal()
        {
            txtResultado.Text += "\r\n ------------------- Prova -------------------- \r\n";

            for (int linha = 0; linha < matrizAumentada.GetLength(0); linha++)
            {
                double resultado = 0;
                for (int coluna = 0; coluna <= matrizAumentada.GetLength(1); coluna++)
                {
                    if (coluna == numVariaveis)
                        txtResultado.Text += $"  = {termosIndependentesIniciais[linha]}  ";
                    else
                    {
                        resultado += matrizAumentada[linha, coluna] * x[coluna];
                        txtResultado.Text += $"  {Math.Round(resultado, 3)}  ";
                    }
                }
                if (Math.Round(resultado) == Math.Round(termosIndependentesIniciais[linha]))
                    txtResultado.Text += " - OK";
                else
                    txtResultado.Text += " - NOP";

                txtResultado.Text += "\r\n";
            }
        }

        /// <summary>
        /// Lê o sistema inserido no GridView realizando validações e salvando na matriz global sistema
        /// </summary>
        /// <returns>Se o sistema for lido com sucesso ele retorna true, se não false</returns>
        bool LerSistema()
        {
            try
            {
                for (int linha = 0; linha < gridSistema.Rows.Count; linha++)
                {
                    for (int coluna = 0; coluna < gridSistema.ColumnCount; coluna++)
                    {
                        string indice = Convert.ToString(gridSistema.Rows[linha].Cells[coluna].Value);


                        if (double.TryParse(indice, out double valor))
                        {
                            if (gridSistema.Rows[0].Cells[0].Value.ToString() == "0")
                            {
                                ShowError("O pivô não pode ser igual a 0");
                                return false;
                            }
                            else if (coluna == numVariaveis)
                            {
                                termosIndependentes[linha] = valor;
                                termosIndependentesIniciais[linha] = valor;
                            }
                            else
                            {
                                sistema[linha, coluna] = valor;
                                matrizAumentada[linha, coluna] = valor;
                            }
                        }
                        else
                        {
                            ShowError("Insira apenas números validos");
                            return false;
                        }
                    }
                }

                return true;
            }
            catch
            {
                ShowError("Insira apenas números validos");
                return false;
            }

        }

        /// <summary>
        /// Exibe o sistema no TextBox
        /// </summary>
        /// <param name="title">Titulo que referencia o sistema</param>
        void WriteSistema(string title)
        {
            txtResultado.Text += $"\r\n------ {title} ------\r\n";
            for (int linha = 0; linha < sistema.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna <= sistema.GetLength(1); coluna++)
                {
                    if (coluna == numVariaveis)
                        txtResultado.Text += $"  {termosIndependentes[linha]}  ";
                    else
                        txtResultado.Text += $"  {sistema[linha, coluna]}  ";
                }
                txtResultado.Text += Environment.NewLine;
            }
        }

        /// <summary>
        /// Exibe uma MessageBox de erro personalizada
        /// </summary>
        /// <param name="message">Mensagem do erro</param>
        void ShowError(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Converte cada sistema de um arquivo .txt em uma matriz e resolve
        /// </summary>
        /// <param name="linhas">Linhas do arquivo .txt</param>
        void LerSistemaImportado(string[] linhas)
        {
            int indiceLinhaArquivo = 0;

            int tamanhoSistema = linhas[0].Split(';').Length - 1;
            numVariaveis = tamanhoSistema;
            int countSistemas = tamanhoSistema;

            sistema = new double[tamanhoSistema, tamanhoSistema];
            termosIndependentes = new double[tamanhoSistema];
            matrizAumentada = new double[tamanhoSistema, tamanhoSistema];
            termosIndependentesIniciais = new double[tamanhoSistema];
            x = new double[tamanhoSistema];

            int indiceLinha = 0;
            while (indiceLinhaArquivo < linhas.Length)
            {
                string[] dadosLinha = linhas[indiceLinhaArquivo].Split(';');
                for (int coluna = 0; coluna < dadosLinha.Length; coluna++)
                {
                    double.TryParse(dadosLinha[coluna], out double valor);
                    if (coluna == tamanhoSistema)
                    {
                        termosIndependentes[indiceLinha] = valor;
                        termosIndependentesIniciais[indiceLinha] = valor;
                    }
                    else
                    {
                        sistema[indiceLinha, coluna] = valor;
                        matrizAumentada[indiceLinha, coluna] = valor;
                    }
                }

                indiceLinhaArquivo++;
                indiceLinha++;
                if (indiceLinhaArquivo == countSistemas)
                {
                    CalcularSistema();

                    if (indiceLinhaArquivo < linhas.Length)
                    {
                        tamanhoSistema = linhas[indiceLinhaArquivo].Split(';').Length - 1;
                        numVariaveis = tamanhoSistema;
                        countSistemas += tamanhoSistema;
                        indiceLinha = 0;
                        sistema = new double[tamanhoSistema, tamanhoSistema];
                        termosIndependentes = new double[tamanhoSistema];
                        matrizAumentada = new double[tamanhoSistema, tamanhoSistema];
                        termosIndependentesIniciais = new double[tamanhoSistema];
                        x = new double[tamanhoSistema];
                    }
                }
            }

        }

        /// <summary>
        /// Faz todo o processos para calcular um sistema
        /// </summary>
        void CalcularSistema()
        {
            WriteSistema("Matriz aumentada");
            EscalonarSistema();
            ResolverSistema();
        }
    }
}
