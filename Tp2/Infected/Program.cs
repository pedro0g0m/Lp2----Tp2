/*
 * <copyright file="Programa.cs" company="Nota20 Lda">
 * Copyright (c) Nota20 Lda. All rights reserved.
 * </copyright>
 * <author>Pedro Moreira</author>
 * <date>5/26/2021 9:45:58 AM</date>
 * <description>
 * Pagina com o  Main. Usado para instanciar os dois controladores.
 * </description>
 */

using System;
using Infected.Controller;


namespace Infected
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlPandemic control = new ControlPandemic();
            ControlHistory control1 = new ControlHistory();
            Console.ReadKey();
        }
    }
}
