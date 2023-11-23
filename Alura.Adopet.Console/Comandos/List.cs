﻿namespace Alura.Adopet.Console;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
internal class List : IComando
{
    public async Task ExercutarAsync(string[] args)
    {
        await ListaPetsAsync();
    }

    private async Task ListaPetsAsync()
    {
        var httpListPet = new HttpClientPet();
        var pets = await httpListPet.ListPetsAsync();

        if (pets != null)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
    }
}


