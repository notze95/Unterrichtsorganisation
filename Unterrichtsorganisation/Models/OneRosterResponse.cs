namespace Unterrichtsorganisation.Models {
    public class OneRosterResponse<T> {
        public List<T> Items { get; }

        public OneRosterResponse(List<T> items) {
            Items = items;
        }
    }
}
