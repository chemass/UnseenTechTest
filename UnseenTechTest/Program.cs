using Microsoft.EntityFrameworkCore;
using UnseenTechTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=words.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets()
   .ProducesValidationProblem();

app.Run();

// Hi!

// Almost the whole of this application was generated by Copilot. 
// I shan't lie, it's great a producing boilerplate!
// I'll assume that the exercise was intended to show my coding skills, and how I'd approach the problem, but given the requirements, generating from an LLM
// was a straightforward exercise (expect lots of this in future interview subjects lol), my prompt being "Generate a solution from the readme"

// The only real changes I made were in validation - specifically setting the StringLength attribute and the display of the error message.
// I will happily discuss this "solution", to show how I would approach this in a real world scenario (scalability, caching, n-layer etc),
// however, the requirements are trivial and there was no need to over-engineer the solution just for the sake of it.

// Will this be heavily used? Metrics and logging would be essential in a real world scenario, but given the requirements, I didn't see the need to add this.
// I would also have added a caching layer, but again, the requirements didn't call for it.

// Text matching: Options include Span<char> style minimal-allocation text matching (provides both performance and memory utilisation benefits, both of which are important in
// cloud based solutions, where you pay for what you use), or using a library such as System.Text.RegularExpressions, which is highly performant and has been improved in the latest dotnet versions.

// Obvoiusly, a regex based solution would be the easiest to implement, and with the recent improvements in the latest dotnet versions, would remain highly performant.

// Finally, we have the lowest level of string matching, which is what we have here - a simple loop. Although it works, it would end up being difficult to maintain.
// Something along the lines of FluentValidation would be a better approach, as it would allow for a more declarative style of validation, and would also allow for a more flexible approach,
// having all of the string validation logic in one place.

// Caching: Given a real world scenario, I would probably adopt a hybrid cache approach - 1st level memory cache with a 2nd level distributed cache. I implemeted this while working at Vuture, 
// although it wes never used in a production environment (the product was moved into maintenance mode before it was fully implemented with a backing redis cache). Nevertheless, it's good
// to see Microsoft delivering a HybridCache package to handle this from a platform level.

