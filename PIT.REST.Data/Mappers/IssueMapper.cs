﻿using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Mappers
{
    public class IssueMapper : BaseMapper<Issue>
    {
        public IssueMapper()
        {
            ToTable("Issues");

            Property(i => i.Description).IsOptional();
            Property(i => i.Description).HasMaxLength(1000);

            Property(i => i.Status).IsRequired();
        }
    }
}