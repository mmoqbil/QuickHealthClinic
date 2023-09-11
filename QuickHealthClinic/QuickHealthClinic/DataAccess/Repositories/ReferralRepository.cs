using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public class ReferralRepository : Repository<Referral>, IReferralRepository
    {
        public ReferralRepository(QuickLifeCoachingClinicContext context) : base(context)
        {
            DbSet = context.Referrals;
        }
    }
}
