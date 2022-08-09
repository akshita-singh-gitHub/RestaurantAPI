namespace restaurant.Data
{
    public class RestoListFunc : IRestoListData
    {
        private readonly DataContext _context;

        public RestoListFunc(DataContext context)
        {
            _context = context;
        }

        public List<RestoList> GetRestoList()
        {

            return _context.Listresto.ToList();
        }
        public List<RestoList> CreateRestoList(RestoList details)
        {
            _context.Listresto.Add(details);
            _context.SaveChanges();

            return _context.Listresto.ToList();
        }
        public List<RestoList> UpdateRestoList(RestoList details, int id)
        {
            var dbresto = _context.Listresto.Find(details.Id);
            if (dbresto != null)
            {

                dbresto.Name = details.Name;
                dbresto.Email = details.Email;
                dbresto.Address = details.Address;
                dbresto.ImageUrl = details.ImageUrl;
                dbresto.Available = details.Available;
            }
            _context.SaveChanges();


            return _context.Listresto.ToList();
        }
        public void DeleteRestoList(RestoList dbresto)
        {
            _context.Listresto.Remove(dbresto);
            _context.SaveChanges();
        }

       

        public RestoList GetRestoById(int id)
        {
            var dbresto = _context.Listresto.Find(id);

            return dbresto;
        }
        //public void SetAvailability(RestoList resto)
            
        //{
        //      if (resto.Available == "true")
        //        resto.Available = "false";
        //    else resto.Available = "true";
        //    _context.SaveChanges();
        //}

    }
}
