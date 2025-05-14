// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.Net;
using mROA.Abstract;
using mROA.Cbor;
using mROA.Codegen;
using mROA.Implementation;
using mROA.Implementation.Backend;
using mROA.Implementation.Bootstrap;
using PlatformerBackend.Api;

var builder = new FullMixBuilder();
builder.Modules.Add(new CborSerializationToolkit());
builder.Modules.Add(new BackendIdentityGenerator());
var listening = new IPEndPoint(IPAddress.Loopback, 4567);
builder.UseNetworkGateway(listening, typeof(ChannelInteractionModule),
    builder.GetModule<IIdentityGenerator>()!);
builder.Modules.Add(new ConnectionHub());
builder.Modules.Add(new HubRequestExtractor());

builder.UseBasicExecution();
builder.Modules.Add(new CreativeRepresentationModuleProducer(
    new IInjectableModule[] { builder.GetModule<IContextualSerializationToolKit>()! },
    typeof(RepresentationModule)));
builder.Modules.Add(new RemoteInstanceRepository());
// builder.UseCollectableContextRepository(typeof(PrinterFactory).Assembly);
builder.Modules.Add(new MultiClientInstanceRepository(i =>
{
    var repo = new InstanceRepository();
    repo.FillSingletons(typeof(AuthService).Assembly);
    repo.Inject(builder.Modules.OfType<CreativeRepresentationModuleProducer>().First());
    return repo;
}));
builder.SetupMethodsRepository(new CoCodegenMethodRepository());

builder.Modules.Add(new CancellationRepository());

builder.Build();
new RemoteTypeBinder();


// _ = builder.GetModule<UdpGateway>()!.Start();
var gateway = builder.GetModule<IGatewayModule>();
gateway.Run();

Console.ReadLine();