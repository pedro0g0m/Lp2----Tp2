/*
 * <copyright file="ControlPandemic.cs" company="Nota20 Lda">
 * Copyright (c) Nota20 Lda. All rights reserved.
 * </copyright>
 * <author>Pedro Moreira</author>
 * <date>5/26/2021 12:20:13 PM</date>
 * <description>
 * Controlador responsavel por interagir com a interface IPessoaModel na camada Model e com a View deste projecto.
 * </description>
 */

using Infected.Model;
using Infected.View;

namespace Infected.Controller
{
    /**
    *  Interface do Controlador de Pessoa.
    *  Está presente, neste interface, os varios métodos para manipular a informação 
    *  do objecto Pessoa, sendo tambem feita a instanciação do Model de Pessoa e do View para possibilitar
    *  o fluxo da informação para as diferentes camadas.
    */
    public interface IPessoaControl
    {
        //controlar Model de Pessoa
        void SetModel(IPessoaModel m);

        //armazenamento de informação
        void PessoaNome(string v);
        void TemCovid(int v);
        void MaisDoencas(string v);

        //busca de informação
        string Nome();
        string Doenca();
        bool Covid();

        //controlar View
        void SetView(IRelatorioView v);

    }

    /**
    *  Classe ControlPandemic. 
    *  Esta classe serve como controlador da informação pedida e enviada para, neste caso, a interface Pessoa. Este fluxo de
    *  informação é controlada e muito restrita pois só é possivel invocar métodos que estejam declarados nas interfaces
    *  respectivas, no model ou na view.
    */
    public class ControlPandemic : IPessoaControl
    {
        #region Variaveis

        private IPessoaModel pess;          /**< Declaração da interface Pessoa */
        private IRelatorioView pessView;    /**< Declaração da interface View */

        #endregion

        #region Metodos

        #region Construtors

        /**
        * Um construtor com parametros.
        * Construtor da classe ControlPandemic...
        */
        public ControlPandemic(IPessoaModel m, IRelatorioView v)
        {
            pess = m;
            pessView = v;
        }

        /**
        * Um construtor sem parametros.
        * Construtor da classe ControlPandemic...
        */
        public ControlPandemic()
        {
            pess = new Pessoa();
            pessView = new RelatorioView(this);

            pessView.RegistaPessoa();
            pessView.GravaLocal();

            pessView.ShowAllPessoa();
            pessView.ShowAllCovid();
        }

        #endregion

        #region OtherMethods

        #region Control_Model
        /**
        * Um método de classe.
        * Atribui a variavel pess o model da interface IPessoaModel...
        */
        public void SetModel(IPessoaModel m)
        {
            this.pess = m;
        }

        #region armazenamento de informação
        /**
         * Um método de classe.
         * Este método recebe por parâmetro uma string sendo o seu conteudo atribuido a variavel
         * nome do objecto Pessoa.
         */
        public void PessoaNome(string v)
        {
            if (pess != null)
            {
                pess.Nome = v;
            }
        }

        /**
         * Um método de classe.
         * Este método recebe por parâmetro uma string sendo o seu conteudo atribuido a variavel
         * doença do objecto Pessoa.
         */
        public void MaisDoencas(string v)
        {
            if (pess != null)
            {
                pess.Doenca = v;
            }
        }

        /**
         * Um método de classe.
         * Este método recebe por parâmetro um integer sendo o seu valor usado para invocar, ou não,
         * o método responsavel por alterar o valor do atributo covid no objecto Pessoa.
         */
        public void TemCovid(int v)
        {
            if (pess != null && v == 1)
            {
                pess.AddInfected();
            }
        }
        #endregion

        #region busca de informação
        /**
         * Um método de classe.
         * Método que invoca outro metodo, sendo este declarado na interface IPessoaModel, que 
         * devolve o valor presente na variavel nome do objecto Pessoa em questão.
         */
        public string Nome()
        {
            return pess.ToString();
        }

        /**
         * Um método de classe.
         * Método que invoca outro metodo, sendo este declarado na interface IPessoaModel, que 
         * devolve o valor presente na variavel doença do objecto Pessoa em questão.
         */
        public string Doenca()
        {
            return pess.Doenca;
        }

        /**
         * Um método de classe.
         * Método que invoca outro metodo, sendo este declarado na interface IPessoaModel, que 
         * devolve o valor presente na variavel covid do objecto Pessoa em questão.
         */
        public bool Covid()
        {
            return pess.Covid;

        }

        #endregion

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
