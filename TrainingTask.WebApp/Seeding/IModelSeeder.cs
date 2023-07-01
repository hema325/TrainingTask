using Microsoft.EntityFrameworkCore;

namespace TrainingTask.WebApp.Seeding
{
    public interface IModelSeeder
    {
        void Seed(ModelBuilder builder);
    }
}
