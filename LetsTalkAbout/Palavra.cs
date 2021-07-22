
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Data;

namespace LetsTalkAbout
{
     public class Palavra
    {
        private char letra;
        public char Letra
        {
            get { return letra; }
            set { letra = value; }

        }

        private int numWord;
        public int NumWord
        {
            get { return numWord; }
            set { numWord = value; }

        }
        //
        private string palavras;
        public string Palavras
        {
            get { return palavras; }
            set { palavras = value; }
        }
        //
        private string abreviatura;
        public string Abreviatura
        {
            get { return abreviatura; }
            set { abreviatura = value; }
        }
        //
        private string[] silabas;
        public string[] Silabas
        {
            get { return silabas; }
            set { silabas = value; }
        }
        public int numSilabas
        {
            get { return Silabas.Length; }
        }
        public struct SignificadoByTipo
        {
            public string tipo;
            public string significados;
            public string area;

            public SignificadoByTipo(string _tipo, string _significados, string _area)
            {
                tipo = _tipo;
                significados = _significados;
                area = _area;

            }

        }

        public List<SignificadoByTipo> SignBytipo;

        public void SetSignByTipo(string _tipo, string _significados, string _area)
        {
            SignificadoByTipo sBT = new SignificadoByTipo(_tipo, _significados, _area);

            SignBytipo.Add(sBT);
            Significados.Add(_significados);
        }
        //
        public List<string> tipo;
        public List<string> Tipos
        {
            get { return tipo; }
            set { tipo = value; }
        }
        //
        public List<string> significado;
        public List<string> Significados
        {
            get { return significado; }
            set { significado = value; }
        }
        //
        public List<string> pronuncia;
        public List<string> Pronuncia
        {
            get { return pronuncia; }
            set { pronuncia = value; }
        }
        //
        public List<string> plural;
        public List<string> Plural
        {
            get { return plural; }
            set { plural = value; }
        }
        string feminino;
        public string Feminino
        {
            get { return feminino; }
            set { feminino = value; }
        }


        public Palavra()
        {
            SignBytipo = new List<SignificadoByTipo>();
            significado = new List<string>();

        }
        public void getPalavras4Xml()
        {

        }
        public void EscreveXmlAberto(XmlTextWriter xmlWriter)
        {
            //inicia Palavra
            xmlWriter.WriteStartElement("Palavra");
            xmlWriter.WriteAttributeString("id", this.palavras);
            xmlWriter.WriteAttributeString("Num", this.numWord.ToString());

            foreach (string sil in silabas)
            {
                //inicia silabas
                xmlWriter.WriteStartElement("Silabas");
                xmlWriter.WriteString(sil);
                //end silabas i
                xmlWriter.WriteEndElement();

            }
            //Abreviatura
            //inicia Abreviatura
            xmlWriter.WriteStartElement("Abreviatura");
            xmlWriter.WriteString(this.abreviatura);
            //end Abreviatura i
            xmlWriter.WriteEndElement();

            //feminino
            //inicia feminino
            xmlWriter.WriteStartElement("Feminino");
            xmlWriter.WriteString(this.feminino);
            //end Abreviatura i
            xmlWriter.WriteEndElement();

            string ultpr = "";
            foreach (string pl in plural)
            {
                if (pl != ultpr)
                {
                    //inicia Plural
                    xmlWriter.WriteStartElement("Plural");
                    xmlWriter.WriteString(pl);
                    //end plural i
                    xmlWriter.WriteEndElement();
                }
                ultpr = pl;
            }
            string ultPr = "";
            foreach (string pr in pronuncia)
            {
                if (ultPr != pr)
                {
                    //inicia pronuncia
                    xmlWriter.WriteStartElement("Pronuncia");
                    xmlWriter.WriteString(pr);
                    //end pronuncia i
                    xmlWriter.WriteEndElement();
                }
                ultPr = pr;
            }
            string ultTp = "";
            foreach (string tp in tipo)
            {
                if (tp != ultTp)
                {
                    //inicia TiposGR
                    xmlWriter.WriteStartElement("TiposGR");
                    xmlWriter.WriteString(tp);
                    //end TiposGR i
                    xmlWriter.WriteEndElement();
                }
                ultTp = tp;
            }
            /*
                        foreach (string sign in significado)
                        {
                            //inicia Significados
                            xmlWriter.WriteStartElement("Significados");
                            xmlWriter.WriteString(sign);
                            //end Significados i
                            xmlWriter.WriteEndElement();

                        }
              */
            //SignBytipo
            string ultsignBt = "";
            foreach (SignificadoByTipo sbT in SignBytipo)
            {
                if (sbT.significados != ultsignBt)
                {
                    //inicia Significados
                    xmlWriter.WriteStartElement("Significados");
                    xmlWriter.WriteAttributeString("Tipo", sbT.tipo);
                    xmlWriter.WriteAttributeString("Area", sbT.area);
                    xmlWriter.WriteString(sbT.significados);
                    //end Significados i
                    xmlWriter.WriteEndElement();
                }
                ultsignBt = sbT.significados;
            }

            //end palavras 
            xmlWriter.WriteEndElement();

        }


    }
}


/*
ARQUEOL. — Arqueologia.
ARQUIT. — Arquitetura.
ART. — Arte.
art. — Artigo.
ASTROL. — Astrologia.
ASTRON. — Astronomia.
BIOL. — Biologia.
BIOQUÍM. — Bioquímica.
BOT. — Botânica.
BRAS. — Brasileirismo.
CHUL. — Chulo.
conj. — Conjunção.
CUL. — Culinária.
DESUS. — Desusado.
ECOL. — Ecologia.
ECON. — Economia.
ESPORT. — Esporte.
etc. — et cetera; outras coisas.
FARM. — Farmacologia.
Fem. — Feminino.
FIG. — Figurado.
FILOS. — Filosofia.
FÍS. — Física.
FÍS. E QUÍM. — Física e Química.
GEOGR. — Geografia.
GEOL. — Geologia.
GEOM. — Geometria.
GRAM. — Gramática.
HIST. — História.
INFORMÁT. — Informática.
interj. — Interjeição.
JUR. — Jurídico.
LITER. — Literatura.
loc. adv. — Locução adverbial.
LUS. — Lusitanismo.
MAT. — Matemática.
MED. — Medicina.
MIT. — Mitologia.
MÚS. — Música.
num. — Numeral.
Onomat. — Onomatopeia.
PALEO. — Paleontologia.
PEJOR. — Pejorativo.
Pl. — Plural.
POÉT. — Poético.
POP. — Popular.
POR EXT. — Por extensão.
prep. — Preposição.
pron. — Pronome.
PSICOL. — Psicologia.
QUÍM. — Química.
RELIG. — Religião.
s.2g. — Substantivo de dois gêneros.
s.2g.2n. — Substantivo de dois gêneros
e dois números.
s.f. — Substantivo feminino.
s.f.pl. — Substantivo feminino plural.
s.m. — Substantivo masculino.
s.m.pl. — Substantivo masculino plural.
Símb. — Símbolo.
v.i. — Verbo intransitivo.
v.pred. — Verbo predicativo.
v.pron. — Verbo pronominal.
v.i. — Verbo intransitivo.
v.t. — Verbo transitivo.
v.t. e v.i. — Verbo transitivo e intransitivo.
Var. — Variante.
VETER. — Veterinária.
ZOOL. — Zoologia.
 */