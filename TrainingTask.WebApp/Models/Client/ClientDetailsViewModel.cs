using TrainingTask.WebApp.Common.Mapping;

namespace TrainingTask.WebApp.Models.Client
{
    public class ClientDetailsViewModel: IMapFrom<Entities.Client>,IMapTo<Entities.Client>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
