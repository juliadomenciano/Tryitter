using tryitter.Models;

namespace tryitter.Repository
{
  public class ModuleRepository
  {
    protected readonly TryitterContext _context;
    public ModuleRepository (TryitterContext context)
    {
      _context = context;
    }
    public Module GetModuleById(int id)
    {
      return _context.Modules.Where(s => s.ModuleId == id).First();
    }
    public IEnumerable<Module> GetModules()
    {
      return _context.Modules.ToList();
    }
    public Module AddModule(Module Module)
    {
      _context.Modules.Add(Module);
      _context.SaveChanges();
      return Module;
    }
    public Module UpdateModule(Module Module)
    {
      _context.Modules.Update(Module);
      _context.SaveChanges();
      return Module;
    }
    public Module DeleteModule(int id)
    {
      var Module = _context.Modules.Find(id);
      _context.Modules.Remove(Module);
      _context.SaveChanges();
      return Module;
    }
  }
}