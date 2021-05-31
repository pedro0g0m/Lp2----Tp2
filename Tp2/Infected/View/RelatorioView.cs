/*
 * <copyright file="RelatorioView.cs" company="Nota20 Lda">
 * Copyright (c) Nota20 Lda. All rights reserved.
 * </copyright>
 * <author>Pedro Moreira</author>
 * <date>5/26/2021 16:26:29 AM</date>
 * <description>
 * RelatorioView.cs é a camada responsavel por responder aos pedidos realizados, neste caso, pela consola. Esta class 
 * comunica com os varios controladores para enviar e/ou receber informação.
 * </description>
 */

using System;
using Infected.Controller;

namespace Infected.View
{
    /**
    *  Interface de IRelatorioView. 
    *  Interface com os métodos que considero necessários para responder as necessidades deste projeto.
    */
    public interface IRelatorioView
    {
        void Menu();
        void RegistaPessoa();
        void GravaLocal();
        void ShowAllPessoa();
        void ShowAllCovid();
    }

    /**
    *  Classe RelatorioView. 
    *  Classe responsável por responder a pedidos de informação ou recolher informação para enviar, através de vários 
    *  métodos, para os controladores competentes.
    */
    public class RelatorioView : IRelatorioView
    {
        #region Attributes
        private IPessoaControl pessControl;     /**< Declaração da interface IPessoaControl */
        private IControlHistory histControl;    /**< Declaração da interface IControlHistory */
        #endregion

        #region Metodos

        #region Constructors
        /**
        * Um construtor com parametros.
        * Construtor da classe RelatorioView...
        */
        public RelatorioView(IPessoaControl pC)
        {
            pessControl = pC;
            pessControl.SetView(this);
        }

        /**
        * Um construtor com parametros.
        * Construtor da classe RelatorioView...
        */
        public RelatorioView(IControlHistory hC)
        {
            histControl = hC;
            histControl.SetView(this);
        }

        #endregion

        #region OtherMethods

        /**
        * Um método de classe.
        * nao será descrito pois será alterado apos a correção de um erro
        */
        public void Menu()
        {
            //Falta implementar
        }

        /**
        * Um método de classe.
        * nao será descrito pois será alterado apos a correção de um erro
        */
        public void RegistaPessoa()
        {
            int resp;

            Console.WriteLine("Nome: ");
            pessControl.PessoaNome(Console.ReadLine());
            Console.WriteLine("\nDoencas adicionais: ");
            pessControl.MaisDoencas(Console.ReadLine());
            do
            {
                Console.WriteLine("\nCovid? (1-sim 0-nao): ");
                resp = int.Parse(Console.ReadLine());
                pessControl.TemCovid(resp);

            } while (resp != 0 && resp != 1);

            Console.WriteLine(pessControl.Nome() + "\n" + pessControl.Covid() + "\n" + pessControl.Doenca());

            histControl.NewPessoa(pessControl);
        }

        /**
        * Um método de classe.
        * nao será descrito pois será alterado apos a correção de um erro
        */
        public void GravaLocal()
        {
            histControl.SaveHistory(@"c:\temp\Tp2.bin");
        }

        /**
        * Um método de classe.
        * nao será descrito pois será alterado apos a correção de um erro
        */
        public void ShowAllPessoa()
        {
            //Falta implementar
        }

        /**
        * Um método de classe.
        * nao será descrito pois será alterado apos a correção de um erro
        */
        public void ShowAllCovid()
        {
            //Falta implementar
        }

        #endregion

        #endregion
    }
}
