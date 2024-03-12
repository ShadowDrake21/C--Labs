using Lab4_task_work.Dao;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllersWithViews();
    var app = builder.Build();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    var applicationLifetime = app.Services
    .GetRequiredService<IHostApplicationLifetime>();
    applicationLifetime.ApplicationStopping.Register(OnShutdown);
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=GetAll}");
    app.Run();
  }
  //Обробник зупинки застосунку
  public static void OnShutdown()
  {
    NHibernateDAOFactory.getInstance().destroy();
  }
}