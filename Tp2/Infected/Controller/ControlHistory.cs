/*
 * <copyright file="ControlHistory.cs" company="Nota20 Lda">
 * Copyright (c) Nota20 Lda. All rights reserved.
 * </copyright>
 * <author>Pedro Moreira</author>
 * <date>5/26/2021 15:09:57 PM</date>
 * <description>
 * Controlador responsavel por interagir com a interface IPessoaHistory na camada Model e com a View deste projecto.
 * </description>
 */

using Infected.Model;
using Infected.View;


namespace Infected.Controller
{
    /**
     *  Interface do Controlador de PessoaHistory.
     *  Está presente declarado, neste interface, os varios métodos para usar responsaveis por interagir com
     *  a classe PessoaHistory, sendo tambem feita a instanciação do Model de PessoaHistory e do View para possibilitar
     *  o fluxo da informação para as diferentes camadas.
     */
    public interface IControlHistory
    {
        void SetModel(IPessoaHistory m);
        void NewPessoa(IPessoaControl p);
        void LoadBDPessoa(int i);
        bool SaveHistory(string s);
        bool LoadHistory(string s);

        //controlar View
        void SetView(IRelatorioView v);


    }

    /**
    *  Classe ControlHistory. 
    *  Esta classe serve para responder os pedidos realizados pelo View invocando métodos declarados na camada Model. Desta maneira
    *  garantimos uma abstração há camada View, responsavel pela interação com o User, do funcionamento interna desta aplicação
    *  oferecendo mais segurança.
    */
    public class ControlHistory : IControlHistory
    {
        #region Attributes
        private IPessoaHistory pessHist;    /**< Declaração da interface PessoaHistory */
        private IRelatorioView pessView;    /**< Declaração da interface View */
        #endregion

        #region Metodos

        #region Constructors

        /**
        * Um construtor com parametros.
        * Construtor da classe ControlHistory...
        */
        public ControlHistory(IPessoaHistory h, IRelatorioView v)
        {
            pessHist = h;
            pessView = v;
        }

        /**
        * Um construtor sem parametros.
        * Construtor da classe ControlHistory...
        */
        public ControlHistory()
        {
            pessHist = new PessoaHistory();
            pessView = new RelatorioView(this);

            pessView.RegistaPessoa();
            pessView.GravaLocal();

            pessView.ShowAllPessoa();
            pessView.ShowAllCovid();
        }

        #endregion

        #region OtherMethods

        /**
         * Um método de classe.
         * Este método recebe por parâmetro uma interface com a informação necessaria para criar e armazenar o objecto Pessoa.
         * O objecto criado é armazenado localmente numa lista e na base de dados.
         */
        public void NewPessoa(IPessoaControl p)
        {
            if (pessHist != null)
            {
                Pessoa pes = new Pessoa(p.Nome(), p.Doenca(), p.Covid());
                pessHist.AddPessoa(pes);
                pessHist.AddBDPessoa(pes);
            }
        }

        /**
         * Um método de classe.
         * Este método recebe por parâmetro um integer que representa o indentificador de um objecto Pessoa, sendo ele
         * usado para procurar, na base de dados online o objecto Pessoa com o mesmo ID, e devolvido o objecto Pessoa encontrado. 
         */
        public void LoadBDPessoa(int i)
        {
            if (pessHist != null)
            {
                pessHist.LoadBDPessoa(i);
            }
        }

        /**
         * Um método de classe.
         * Este método recebe por parâmetro uma string com o caminho onde para armazenar o ficheiro. Este ficheiro ira conter
         * todos os objectos Pessoa guardada na lista.
         */
        public bool SaveHistory(string s)
        {
            if (pessHist != null)
            {
                return pessHist.SaveHistory(s);
            }
            return false;
        }

        /**
         * Um método de classe.
         * Este método recebe por parâmetro uma string com o caminho que indica a localização dele. Neste ficheiro ira conter 
         * uma lista com os objectos Pessoas previamente criadas.
         */
        public bool LoadHistory(string s)
        {
            if (pessHist != null)
            {
                return pessHist.LoadHistory(s);
            }
            return false;
        }


        #region Control_Model
        /**
        * Um método de classe.
        * Atribui a variavel pess o model da interface IPessoaModel...
        */
        public void SetModel(IPessoaHistory m)
        {
            this.pessHist = m;
        }


        #endregion

        #region Control_View
        /**
        * Um método de classe.
        * Atribui a variavel pessView o view da interface IRelatorioView...
        */
        public void SetView(IRelatorioView v)
        {
            this.pessView = v;
        }

        #endregion

        #endregion

        #endregion




    }
}
