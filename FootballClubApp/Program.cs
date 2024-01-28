using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<IPlayerProvider, PlayerProvider>();
services.AddSingleton<ISpecificInfoProvider, SpecificInfoProvider>();

// Since only ONE implementation of the repository can be injected under a specific abstraction (IRepository<T>),
// the user must comment out either ListRepository or SqlRepository, depending on which one wants to work with.
// It is not possible to operate on both simultaneously, ensuring that the logic is maintained!

//services.AddSingleton<IRepository<Player>, ListRepository<Player>>();            // ListRepository
//services.AddSingleton<IRepository<Opponent>, ListRepository<Opponent>>();        // ListRepository
//services.AddSingleton<IDataGenerator, DataGeneratorListRepository>();              // ListRepository
services.AddSingleton<IRepository<Player>, SqlRepository<Player>>();            // SQLRepository
services.AddSingleton<IRepository<Opponent>, SqlRepository<Opponent>>();        // SQLRepository
services.AddSingleton<IDataGenerator, DataGeneratorSql>();                     // SQLRepository
services.AddDbContext<FootballClubAppDbContext>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();

app.Run();