/*
 * <copyright file="PessoaHistory.cs" company="Nota20 Lda">
 * Copyright (c) Nota20 Lda. All rights reserved.
 * </copyright>
 * <author>Pedro Moreira</author>
 * <date>5/26/2021 10:47:45 AM</date>
 * <description>
 * PessoaHistory.cs tem todos os metodos necessarios para gerar um objeto do tipo Pessoa.
 * A classe Pessoa responde a um interface com os metodos que considero necessarios para
 * criar e gerir a infomação do objeto Pessoa.
 * </description>
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Infected.Model
{
    /**
    *  Interface de PessoaHistory. 
    *  Interface com os métodos que considero necessários para 
    *  gravar, localmente ou numa base de dados online -Firebase-, a lista com os objectos Pessoa nela armazenados.
    */
    public interface IPessoaHistory
    {
        bool AddPessoa(IPessoaModel i);
        void AddBDPessoa(IPessoaModel i);
        void LoadBDPessoa(int i);
        bool SaveHistory(string fileName);
        bool LoadHistory(string fileName);

    }

    /**
    *  Classe PessoaHistory. 
    *  Classe responsável por gerar a lista onde são guardados os objectos Pessoa e respeita o interface IPessoaHistory.
    *  Tem os métodos para guardar/carregar a lista em ficheiro, também tem os métodos para guardar
    *  objectos numa base de dados online. 
    *  A classe é Serializable para permitir que a lista possa ser armazanado num ficheiro.
    */
    [Serializable]
    public class PessoaHistory : IPessoaHistory
    {
        #region Variaveis

        List<IPessoaModel> hist; /**< List hist para guardar obj Pessoa */

        #endregion

        #region Firebase Setup
        /**
        *  Configuração Firebase. Instanciação do objecto FirebaseConfig com os parametros
        *  necessários para configurar uma ligação com a base de dados online.
        */
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvI2gSB51OOZ0mwnJes1pIOPcJYQp92lZ9osv638",
            BasePath = "https://lp2-tp2-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        #endregion

        #region Metodos

        #region Constructors
        /**
        * Um construtor sem parametros.
        * Construtor da classe PessoaHistory criando a lista para armazenar objectos Pessoa,
        * passados atraves de uma interface.
        */
        public PessoaHistory()
        {
            hist = new List<IPessoaModel>();
        }

        #endregion

        #region OtherMethods
        /**
        * Um método de classe.
        * Recebe um objecto Pessoa proveniente de uma interface e depois de verificar que
        * existe a lista hist e que o objecto Pessoa não é repetido este será gravado na lista. 
        */
        public bool AddPessoa(IPessoaModel i)
        {
            if (hist != null)
                if (!hist.Contains(i))
                {
                    hist.Add(i);
                    return true;
                }
            return false;
        }

        /**
        * Um método assíncrono de classe.
        * Este é um método assíncrono, ou seja, funciona com promessas. Primeiro é criado um cliente com a
        * configuração já declarada anteriormente estabelecendo assim uma connecção com a base de dados. Após 
        * verificar que existe um cliente é lhe enviado dois parametros, o primeiro, é nome da tabela (ListaPacientes) com
        * o identificador de cada objeto (IdPessoa), e o segundo, o objecto Pessoa.
        */
        public async void AddBDPessoa(IPessoaModel i)
        {
            IFirebaseClient client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                SetResponse response = await client.SetTaskAsync("ListaPacientes" + i.IdPessoa, i);
                IPessoaModel result = response.ResultAs<IPessoaModel>();
            }

        }

        /**
        * Um método assíncrono de classe.
        * Este é um método assíncrono, ou seja, funciona com promessas. Este recebe de parametro um integer
        * que será o identificador do objecto Pessoa que queremos selecionar. Após a verificação que o cliente existe
        * é esperado que seja devolvido o objecto Pessoa com o identificador recebido por parametro.
        */
        public async void LoadBDPessoa(int i)
        {
            IFirebaseClient client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                FirebaseResponse response = await client.GetTaskAsync("ListaPacientes" + i);
                IPessoaModel obj = response.ResultAs<IPessoaModel>();
            }
        }

        /**
        * Um método de classe.
        * Método responsavel por guardar num ficheiro local a lista que contem todas os objectos Pessoa
        * criados. Recebe por parametro uma string que representa o caminho para uma pasta local onde
        * será armazenado o ficheiro criado.
        */
        public bool SaveHistory(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, hist);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            return false;
        }


        /**
         * Um método de classe.
         * Método responsavel por carregar para memória uma lista, guardada previamente, com 
         * todos os objectos que nela estiverem armazenado. Este método recebe uma string, por parametro,
         * que representa o caminho local de onde o ficheiro estará armazenado
         */
        public bool LoadHistory(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    hist = (List<IPessoaModel>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            return false;
        }

        #endregion

        #endregion
    }
}
