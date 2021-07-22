using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;


namespace LetsTalkAbout
{
    public partial class Form1 : Form
    {
        Palavra palavra = new Palavra();
        List<Palavra> dicionario = new List<Palavra>();
        int numSilabasFunc =0;
        int countDifs = 0;

        public Form1()
        {
          
            InitializeComponent();
            this.dadosLista = new AutoCompleteStringCollection();
            this.tb_palavra.AutoCompleteCustomSource = dadosLista;
            getWords();

           
            
        }
        public void getWords()
        {
             palavra = new Palavra();
             dicionario = new List<Palavra>();

            double timeIni = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"dicionarioA-Z.xml");

            XmlNodeList nodeLetras = xmlDoc.LastChild.ChildNodes;

            foreach (XmlNode node in nodeLetras)
            {
                XmlNodeList nodePalavras = node.ChildNodes;

                foreach (XmlNode nWord in nodePalavras)
                {
                    palavra.Palavras = nWord.Attributes[0].Value;
                    palavra.NumWord = Convert.ToInt32(nWord.Attributes[1].Value);
                    palavra.Letra = Convert.ToChar(node.Attributes[0].Value);


                    XmlNodeList silabaNode = nWord.SelectNodes("Silabas");
                    //silabas 
                    if (silabaNode.Count > 0)
                    {
                        string silabas = "";
                        for (int i = 0; i < silabaNode.Count; i++)
                        {
                            if (silabas != "") silabas = silabas + ".";
                            silabas = silabas + silabaNode[i].InnerText.ToString();
                        }
                        palavra.Silabas = silabas.Split('.');
                    }

                    XmlNodeList AbreviaturaaNode = nWord.SelectNodes("Abreviatura");
                    if (AbreviaturaaNode.Count > 0)
                    {
                        palavra.Abreviatura = AbreviaturaaNode[0].InnerText.ToString();
                    }
                    XmlNodeList femininoNode = nWord.SelectNodes("Feminino");
                    if (femininoNode.Count > 0)
                    {
                        palavra.Feminino = femininoNode[0].InnerText.ToString();
                    }

                    //Plural 
                    XmlNodeList pluralNode = nWord.SelectNodes("Plural");
                    if (pluralNode.Count > 0)
                    {
                        List<string> plurais = new List<string>();
                        for (int i = 0; i < pluralNode.Count; i++)
                        {
                            plurais.Add(pluralNode[i].InnerText.ToString());
                        }
                        palavra.Plural = plurais;
                    }

                    //pronuncia 
                    XmlNodeList pronuncialNode = nWord.SelectNodes("Pronuncia");
                    if (pronuncialNode.Count > 0)
                    {
                        List<string> pronuncias = new List<string>();
                        for (int i = 0; i < pronuncialNode.Count; i++)
                        {
                            pronuncias.Add(pronuncialNode[i].InnerText.ToString());
                        }
                        palavra.Pronuncia = pronuncias;
                    }
                    //significado
                    XmlNodeList significadoNode = nWord.SelectNodes("Significados");
                    if (significadoNode.Count > 0)
                    {

                        for (int i = 0; i < significadoNode.Count; i++)
                        {
                            palavra.SetSignByTipo(significadoNode[i].Attributes[0].Value, significadoNode[i].InnerText.ToString(), significadoNode[i].Attributes[1].Value);

                        }

                    }

                    this.dadosLista.Add(palavra.Palavras);
                    dicionario.Add(palavra);
                   
                    //teste de silabas 
                    int numSil = palavra.numSilabas;
                    Silabas(palavra.Palavras);
                    if (numSil != numSilabasFunc)
                    {
                        countDifs++;
                    }


                    palavra = new Palavra();
                }

            }

            double totalMill = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;
      

        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {

            buscaPalavra();
        }

        private void tb_palavra_TextChanged(object sender, EventArgs e)
        {

            buscaPalavra();
         
        }
        private string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
        private void buscaPalavra()
        {
            //  string digitado = RemoveAccents(this.tb_palavra.Text);
            string digitado = this.tb_palavra.Text;
            if (digitado != "")
            {
                this.tb_traducao.Text = "";

                //falta tratar acentuação na busca, buscar com e sem ....não fica legal heheh
                // var filteredOrders = dicionario.Where(o => RemoveAccents(o.Palavras.Replace(" ", "")) == digitado.Replace(" ", ""));
                var filteredOrders = dicionario.Where(o => o.Palavras.Replace(" ", "") == digitado.Replace(" ", ""));
                //validação não esta ok, pois nunca é null
                if (filteredOrders != null)
                {
                    string signs = System.Environment.NewLine;
                    //Palavra p = (Palavra)filteredOrders;


                    foreach (Palavra filter in filteredOrders)
                    {
                        var str = filter.SignBytipo;
                        int i = 1;
                        foreach (var s in filter.SignBytipo)
                        {
                            string area = s.area == "" ? "" : " (" + s.area + ") ";
                            string tipo = s.tipo == "" ? "" : " (" + s.tipo + ") ";
                            signs = signs + (i).ToString() + area + tipo + s.significados + System.Environment.NewLine;
                            this.lb_countVogaisClasse.Text = filter.numSilabas.ToString();
                            Silabas(digitado);
                            i++;
                        }

                    }

                    if(signs != System.Environment.NewLine)
                    this.tb_traducao.Text = "Significados:" + signs;
                    else //quebrar palavra para procurar semelhante 
                        ProcuraSemelhantes();

                }
             
            }
        }
        // Função para Teste de silabas... 
        private void Silabas(string _palavra)
        {
            //http://portugues.uol.com.br/gramatica/silaba-divisao-silabica.html
            string palavraInteira = _palavra;
           
            //Auxiliar sem acentos e tudo maiusculo
            string auxPalavra = RemoveAccents(palavraInteira).ToUpper();
            string vogais = "AEIOU";
            int countVogais = 0;
            //foreach (char a in auxPalavra)
           for (int i = 0;i <= auxPalavra.Replace(" ","").Length -1; i++)
           {
                    char a = auxPalavra[i];
                if (vogais.IndexOf(a) >= 0)
                { 
                countVogais++;

                    //desconsiderar uma vogal após a contada se for a proxima lida 
                    i++;
                }
            }

            lb_countVogais.Text = countVogais.ToString();
            numSilabasFunc = countVogais;

        }

        private void ProcuraSemelhantes()
        {

            string digitado = this.tb_palavra.Text;

            var filteredsem = dicionario.Where(o => o.Palavras.Replace(" ", "") == digitado.Replace(" ", ""));
            this.tb_traducao.Text = "";
            //validação não esta ok 
            if (filteredsem != null)
            {
                //subtrair letras ate chegar na primeira letra ou primeira vogal "A E I O U" com ou sem acentos
                //buscar por silabas e depois verificar se existem palavras com a proxima letra
                string signs = System.Environment.NewLine;

                string subString = "AEIOU";

                
                int posLetter = RemoveAccents(digitado.ToUpper()).IndexOf(subString);

       
                    for (int i = digitado.Length; i >= 0; i--)
                {
                    filteredsem = dicionario.Where(o => o.Palavras.Replace(" ", "") == digitado[digitado.Length - i].ToString().Replace(" ", ""));
                    bool continua = false;
                    if (filteredsem != null)
                    {
                        foreach (Palavra filter in filteredsem)
                        {
                                string strsilabas = "";
                            for (int k = filter.Silabas.Length; k >= 0; k--)
                            {
                                for (int j = 0; j <= k; j++)
                                {
                                    strsilabas = strsilabas + filter.Silabas[j];

                                    if (strsilabas == filter.Palavras)
                                    {
                                        
                                        continua = true;
                                        break;
                                    }
                                }


                            }

                           
                            var str = filter.SignBytipo;
                            int l = 1;
                            if (continua)
                            {
                                foreach (var s in filter.SignBytipo)
                                {

                                    string area = s.area == "" ? "" : " (" + s.area + ") ";
                                    string tipo = s.tipo == "" ? "" : " (" + s.tipo + ") ";
                                    signs = signs + (l).ToString() + area + tipo + s.significados + System.Environment.NewLine;
                                    
                                    l++;
                                }
                            }
                        }


                        this.tb_traducao.Text = "Significados:" + signs;
                        
                        break;
                    }

                }
            }
        
        }

    }
}
