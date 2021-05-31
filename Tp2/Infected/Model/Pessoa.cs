/*
 * <copyright file="Pessoa.cs" company="Nota20 Lda">
 * Copyright (c) Nota20 Lda. All rights reserved.
 * </copyright>
 * <author>Pedro Moreira</author>
 * <date>5/26/2021 9:47:45 AM</date>
 * <description>
 * Pessoa.cs tem todos os metodos necessarios para gerar um objeto do tipo Pessoa.
 * A classe Pessoa responde a um interface com os metodos que considero necessarios para
 * criar e gerir a infomação do objeto Pessoa.
 * </description>
 */

using System;


namespace Infected.Model
{
    /**
    *  Interface de Pessoa.
    *  Interface com os metodos que considero necessarios para a gestao 
    * da informação do objecto Pessoa, garantindo que a sua informação é
    * manipulada de uma forma controlada.
    */
    public interface IPessoaModel
    {
        string Nome { get; set; }
        string Doenca { get; set; }
        int IdPessoa { get; }
        bool Covid { get; }

        string ToString();

        void AddInfected();
    }


    /**
    *  Classe Pessoa. 
    *  Classe responsavel por gerar os objectos do tipo Pessoa e respeita o interface IPessoaModel. 
    *  Tem os construtores e os varios metodos que manipulam as suas variaveis. A classe é Serializable para permitir que o objecto Pessoa possa ser armazanado num ficheiro.
    */
    [Serializable]
    public class Pessoa : IPessoaModel
    {
        #region Variaveis
        private int ID;         /**< int ID para identificar o objecto Pessoa criado. */
        private string nome;    /**< string para guardar o nome do objecto Pessoa. */
        private bool covid;     /**< Bool - true caso esteja infetado, false caso não estaja infetado. */
        private string doenca;  /**< string para descrever mais alguma condição/doença.  */
        DateTime d;             /**< DataTime com a hora que o objecto Pessoa foi criado. */
        #endregion

        #region Metodos

        #region Constructors
        /**
        * Um construtor sem parametros.
        * Construtor para o objecto Pessoa. Todos os objectos originados deste
        * construtor têm de base um identificador, a variavel Covid é de base negativa
        * e tem a data da sua criação.
        */
        public Pessoa()
        {
            ID += 1;
            covid = false;
            d = DateTime.Today;
        }

        /**
        * Um construtor com parametros.
        * Construtor para o objecto Pessoa que recebe, por parametro, toda a informação necessaria
        * para criar um objecto Pessoa com todas as suas variaveis preenchidas.
        * Todos os objectos originados deste construtor têm de base um identificador, 
        * a variavel Covid é de base negativa e tem a data da sua criação.
        */
        public Pessoa(string n, string doen, bool c)
        {
            ID += 1;
            nome = n;
            doenca = doen;
            covid = c;
            d = DateTime.Today;
        }

        #endregion

        #region Properties
        /**
        * Um metodo de classe.
        * Metodo responsavel por popular a variavel nome, do objecto Pessoa, com a informção presente numa string
        * ou devolver a informação nome de um objecto Pessoa já criado.
        */
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /**
        * Um metodo de classe.
        * Metodo responsavel por popular a variavel doença, do objecto Pessoa, com a informção presente numa string
        * ou returnar a informação da variavel doenca de um objecto Pessoa já criado.
        */
        public string Doenca
        {
            get { return doenca; }
            set { doenca = value; }
        }

        /**
        * Um metodo de classe.
        * Metodo responsavel por retornar, integer, o identificador de um obejecto Pessoa já criado.
        */
        public int IdPessoa => ID;

        /**
        * Um metodo de classe.
        * Metodo responsavel por retornar um booleano indicando se a Pessoa em questão esta infectada.
        */
        public bool Covid => covid;

        #endregion

        #region Overrides
        /**
        * Override da metodo Equal
        * Compara o objecto Pessoa com outro objecto pessoa recebido por parametro. Realiza a comparação por Nome.
        */
        public override bool Equals(object obj)
        {
            Pessoa p = (Pessoa)obj;
            return (String.Compare(p.nome, this.nome) == 0);
        }

        /**
        * Override da metodo ToString
        * Reescrição do ToString de maneira a imprimir, numa string, a informção, o nome neste caso, do objecto Pessoa.
        */
        public override string ToString()
        {
            return "Nome: " + nome;
        }

        #endregion

        #region Operadores

        /**
        * Override do operador igual.
        * O operador recebe por parametro dois objectos Pessoa e compara-os. Retorna verdadeiro ou falso consoante
        * o resultado da sua comparação.
        */
        public static bool operator ==(Pessoa p1, Pessoa p2)
        {
            return p1.Equals(p2);
        }

        /**
        * Override do operador diferente.
        * O operador recebe por parametro dois objectos Pessoa e compara-os. Retorna verdadeiro ou falso consoante
        * o resultado da sua comparação.
        */
        public static bool operator !=(Pessoa p1, Pessoa p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region OtherMethods
        /**
        * Um metodo de classe.
        * Os objectos Pessoas são criados com a variavel covid igual a falso. Este metodo 
        * altera para verdadeiro quando utilizado.
        */
        public void AddInfected()
        {
            covid = true;
        }
        #endregion

        #region Destructor
        /**
        * O desconstrutor do objecto Pessoa
        */
        ~Pessoa()
        {
        }
        #endregion

        #endregion
    }
}
