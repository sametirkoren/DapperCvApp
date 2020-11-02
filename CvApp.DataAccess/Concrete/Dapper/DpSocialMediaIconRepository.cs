using CvApp.DataAccess.Interfaces;
using CvApp.Entities.Concrete;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CvApp.DataAccess.Concrete.Dapper
{
    public class DpSocialMediaIconRepository : DpGenericRepository<SocialMediaIcon>, ISocialMediaIconRepository
    {
        private readonly IDbConnection _connection;

        public DpSocialMediaIconRepository(IDbConnection connection):base(connection)
        {
            _connection = connection;
        }

        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            return _connection.Query<SocialMediaIcon>("select * from SocialMediaIcons where AppUserId=@id", new
            {
                id = userId
            }).ToList();
        }
    }
}
