using System;

namespace NPS
{
    class Funcoes
    {
        // Calculo da quantidade de clientes para uma pesquisa de NPS satisfatória
        public static int Amostra(int totalClientes)
        {
            double x90 = Math.Pow(2.57 / 0.02, 2) * 0.5 * 0.5;
            return (int)((totalClientes * x90) / (totalClientes + x90));
        }

        // Calculo da quantidade mínima de disparos com base em um aproveitamento de 25% de respostas
        public static int Disparos(int amostra)
        {
            return (int)(amostra / 0.25);
        }

        // Função para calculo do NPS
        public static int NPS(int d, int n, int p)
        {
            double total = d + n + p;

            return (int)(100 * (p - d) / total);
        }



        // Função para calculo da variância
        public static double VarNPS(int d, int n, int p)
        {
            int nps = NPS(d, n, p);
            double total = d + n + p;

            return d / total * Math.Pow((-1.0 - nps / 100.0), 2) + n / total * Math.Pow((-nps / 100.0), 2) + p / total * Math.Pow((1.0 - nps / 100.0), 2);
        }

        // Função para calculo da margem de erro
        public static double MoeNPS(int d, int n, int p)
        {
            double total = d + n + p;
            return 100 * Math.Sqrt(VarNPS(d, n, p) / total);
        }

        // Intervalo de confiança e margem de erro com base no nível de confiança
        public static string IntervaloConfianca(int d, int n, int p)
        {
            // Intervalo para 90% confiança
            double _90inf = NPS(d, n, p) - 1.64 * MoeNPS(d, n, p);
            double _90sup = NPS(d, n, p) + 1.64 * MoeNPS(d, n, p);

            // Intervalo para 95% confiança
            double _95inf = NPS(d, n, p) - 1.96 * MoeNPS(d, n, p);
            double _95sup = NPS(d, n, p) + 1.96 * MoeNPS(d, n, p);

            // Intervalo para 99% confiança
            double _99inf = NPS(d, n, p) - 2.57 * MoeNPS(d, n, p);
            double _99sup = NPS(d, n, p) + 2.57 * MoeNPS(d, n, p);

            return "Margem de erro: " + (1.64 * MoeNPS(d, n, p)).ToString("F2") + "% - " + "Intervalo para 90% de confiança: [" + (int)_90inf + "," + (int)_90sup + "]\n"
                + "Margem de erro: " + (1.96 * MoeNPS(d, n, p)).ToString("F2") + "% - " + "Intervalo para 95% de confiança: [" + (int)_95inf + "," + (int)_95sup + "]\n"
                + "Margem de erro: " + (2.57 * MoeNPS(d, n, p)).ToString("F2") + "% - " + "Intervalo para 99% de confiança: [" + (int)_99inf + "," + (int)_99sup + "]";
        }
    }
}
