using DataGridView_Adm_Com.Models;

namespace MethodsLibrary
{
    public class Methods
    {
        private List<Entrant> entrants = new List<Entrant>();

        public Entrant GetTypeOf()
        {
            return new Entrant();
        }

        public List<Entrant> GetEntrants()
        {
            return entrants;
        }

        public Entrant AddEntrant(Entrant entrant)
        {
            entrants.Add(entrant);
            return entrant;
        }

        public void EditEntrant(Entrant oldValue, Entrant newValue)
        {
            entrants[entrants.IndexOf(oldValue)] = newValue;
        }

        public void DeleteEntrant(Entrant oldValue)
        {
            entrants.Remove(oldValue);
        }

        public int GetCountOnlyPassed()
        {
            return entrants.Where(x => x.MathExams + x.RussianExams + x.ITExams > 150).Count();
        }
    }
}
