namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
using FluentResults;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet _httpClientPet;
    private readonly LeitorDeArquivo _leitorDeArquivo;

    public Import(HttpClientPet httpClientPet, LeitorDeArquivo leitorDeArquivo)
    {
        _httpClientPet = httpClientPet;
        _leitorDeArquivo = leitorDeArquivo;
    }

    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await ImportacaoArquivoPetAsync(args[1]);

    }

    private async Task<Result> ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        try
        {
            var listaDePet = _leitorDeArquivo.RealizaLeitura()!;

            foreach (var pet in listaDePet)
            {
                await _httpClientPet.CreatePetAsync(pet);
            }

            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação realizada com sucesso!"));
        }
        catch (Exception excpetion)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(excpetion));
        }
    }
}

