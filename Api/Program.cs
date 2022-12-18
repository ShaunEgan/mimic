using Api;
using Application;
using Application.Experiments.Commands.RunExperiment;
using Contracts.Experiments;
using MapsterMapper;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.Services.AddApplication();
}

var app = builder.Build();

app.MapPost("/experiment", async (IMapper mapper, ISender mediatr, RunExperimentRequest request) =>
{
    var command = mapper.Map<RunExperimentCommand>(request);
    
    var result = await mediatr.Send(command);

    return mapper.Map<RunExperimentResponse>(result);
});

app.Run();
