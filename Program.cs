using Microsoft.EntityFrameworkCore;
using HL7_EHR_SQLite_Demo;
using HL7_EHR_SQLite_Demo.DataModel;

class Program
{
    static void Main()
    {
        var connectionString = "Data Source=example.db";

        var options = new DbContextOptionsBuilder<EHRDBContext>().UseSqlite(connectionString).Options;

        using EHRDBContext ctx = new(options);
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
        RunAnalysisQueries(ctx);
    }


    static void RunAnalysisQueries(EHRDBContext ctx)
    {
        // Query 1: Number of acts per patient
        var patientRoleId = ctx.Roles.First(r => r.RoleClass == Role.ERoleClass.patient).Id;
        var actsPerPatient = ctx.Participations
            .Where(p => p.RoleId == patientRoleId)
            .GroupBy(p => p.RoleId)
            .Select(g => new { RoleId = g.Key, Count = g.Count() })
            .ToList();

        Console.WriteLine("Number of acts per patient role: ");
        foreach (var item in actsPerPatient)
        {
            Console.WriteLine($"RoleId: {item.RoleId}, Acts: {item.Count}");
        }
        Console.WriteLine();

        // Query 2: Most active provider (by number of acts performed)
        var providerRoleId = ctx.Roles.First(r => r.RoleClass == Role.ERoleClass.author).Id;
        var actsPerProvider = ctx.Participations
            .Where(p => p.RoleId == providerRoleId)
            .GroupBy(p => p.RoleId)
            .Select(g => new { RoleId = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ToList();

        Console.WriteLine("Number of acts per provider role: ");
        foreach (var item in actsPerProvider)
        {
            Console.WriteLine($"RoleId: {item.RoleId}, Acts: {item.Count}");
        }
        Console.WriteLine();

        // Query 3: Number of acts by type (Encounter, Procedure, etc.)
        var actsByType = ctx.Acts
            .GroupBy(a => a.ClassCode)
            .Select(g => new { Type = g.Key, Count = g.Count() })
            .ToList();
        Console.WriteLine("Number of acts by type:");
        foreach (var item in actsByType)
        {
            Console.WriteLine($"Type: {item.Type}, Count: {item.Count}");
        }
        Console.WriteLine();

        // Query 4: List all patients and the number of acts they participated in
        var patientActs = ctx.Participations
            .Where(p => p.RoleId == patientRoleId)
            .GroupBy(p => p.ActId)
            .Select(g => new { ActId = g.Key, Count = g.Count() })
            .ToList();
        Console.WriteLine("Acts per patient (by act id):");
        foreach (var item in patientActs)
        {
            Console.WriteLine($"ActId: {item.ActId}, Count: {item.Count}");
        }
        Console.WriteLine();

        // Query 5: Average number of acts per provider
        var avgActsPerProvider = ctx.Participations
            .Where(p => p.RoleId == providerRoleId)
            .GroupBy(p => p.RoleId)
            .Select(g => g.Count())
            .DefaultIfEmpty(0)
            .Average();
        Console.WriteLine($"Average number of acts per provider role: {avgActsPerProvider:F2}\n");
    }
}
