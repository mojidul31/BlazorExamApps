using BlazorExamApps.Shared.Models;
using System;

namespace BlazorExamApps.Server.Data
{
    public class ElementRepositoryImpl: IElementRepository
    {
        private readonly ApplicationDBContext _context;

        public ElementRepositoryImpl(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool CreateElements(Elements elements)
        {
            try
            {
                _context.Elements.Add(elements);
                _context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                throw new Exception("Fail to Save! "+ ex.Message);
            }
        }

        public bool UpdateElements(Elements elements)
        {
            try
            {
                _context.Elements.Update(elements);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to Update! " + ex.Message);
            }

        }

        public bool DeleteElements(int id)
        {
            try
            {
                var entity = _context.Elements.First(t => t.Id == id);
                _context.Elements.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to Delete! " + ex.Message);
            }

        }

        public Elements GetElements(int id)
        {
            return _context.Elements.First(t => t.Id == id);
        }

        public List<Elements> GetElementList()
        {
            return _context.Elements.ToList();
        }

    }
}
