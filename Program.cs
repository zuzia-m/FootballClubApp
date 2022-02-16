global using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<IRepository<Player>, ListRepository<Player>>();            // ListRepository
services.AddSingleton<IRepository<Opponent>, ListRepository<Opponent>>();        // ListRepository
services.AddSingleton<IDataProvider, DataProviderListRepository>();              // ListRepository
//services.AddSingleton<IRepository<Player>, SqlRepository<Player>>();            // SQLRepository
//services.AddSingleton<IRepository<Opponent>, SqlRepository<Opponent>>();        // SQLRepository
//services.AddSingleton<IDataProvider, DataProviderSql>();                        // SQLRepository
//services.AddDbContext<FootballClubAppDbContext>();                              // SQLRepository

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();

app.Run();