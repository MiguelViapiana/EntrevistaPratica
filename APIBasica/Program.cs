
using APIBasica.models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Cliente> clientes = [
    new Cliente("Miguel"),
    new Cliente("Yasmim"),
    new Cliente("Arnaldo"),
    new Cliente("Marcel")
];


app.MapGet("api/", ()=>"Api básica");

app.MapGet("/api/clientes/listar", () => clientes);

app.MapGet("api/clientes/listar/{nome}", ([FromRoute] string nome)=>{
    for (int i = 0; i< clientes.Count; i++)
    {
        if(clientes[i].Nome == nome)
        {
            return Results.Ok(clientes[i]);
        }
    }
    return Results.NotFound("Cliente não encontrado");
});

app.MapPost("/api/clientes/adicionar/", ([FromBody] Cliente cliente)=>{
    clientes.Add(cliente);
    return Results.Created("", cliente);
});

app.MapPatch("api/clientes/alterar/{nome}/{novoNome}", ([FromRoute] String nome, [FromRoute] String novoNome)=>{
    for (int i = 0; i< clientes.Count; i++)
    {
        if(clientes[i].Nome == nome)
        {
            clientes[i].Nome = novoNome;
            return Results.Ok("Nome alterado!!");
        }
    }
    return Results.NotFound("Cliente não encontrado");

});

app.MapDelete("api/clientes/deletar/{nome}", ([FromRoute] String nome)=>{
        for (int i = 0; i< clientes.Count; i++)
    {
        if(clientes[i].Nome == nome)
        {
            clientes.Remove(clientes[i]);
            return Results.Ok("Cliente removido");
        }
    }
    return Results.NotFound("Cliente não encontrado");
});

app.Run();
