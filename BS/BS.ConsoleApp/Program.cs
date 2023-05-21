using BS.ConsoleApp.Bootstrappers;
using BS.ConsoleApp.Services;

var service = ContainerHelper.GetService<IConsoleGameService>();
service.RunConsoleGameLoop();


