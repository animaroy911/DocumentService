using DocumentService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.HandyMember.Any())
                {
                    context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('HandyMember', RESEED, 0)");
                    var HandyMembers = new HandyMember[]
                    {
                        new HandyMember
                        {
                            FirstName = "Carson",
                            LastName = "Alexander",
                            DateOfBirth = DateTime.Parse("2005-09-01"),
                            Email = "abcd@hotmail.com",
                            Phone = "778-123-4567",
                            Street = "880 Granville St",
                            City = "Vancouver",
                            ZIP = "V3D1N9",
                        },
                        new HandyMember
                        {
                            FirstName = "Meredith",
                            LastName = "Alonso",
                            DateOfBirth = DateTime.Parse("2002-09-01"),
                            Email = "efgh@hotmail.com",
                            Phone = "778-123-4567",
                            Street = "880 Royal Oak St",
                            City = "Burnaby",
                            ZIP = "V3R1E9"
                        },
                        new HandyMember
                        {
                            FirstName = "Arturo",
                            LastName = "Anand",
                            DateOfBirth = DateTime.Parse("2003-09-01"),
                            Email = "ijk@hotmail.com",
                            Phone = "778-123-4567",
                            Street = "880 Granville St",
                            City = "Vancouver",
                            ZIP = "V3D1N9"
                        },
                        new HandyMember
                        {
                            FirstName = "Gytis",
                            LastName = "Barzdukas",
                            DateOfBirth = DateTime.Parse("2002-09-01"),
                            Email = "lmn@hotmail.com",
                            Phone = "778-123-4567",
                            Street = "880 Granville St",
                            City = "Vancouver",
                            ZIP = "V3D1N9"
                        },
                        new HandyMember
                        {
                            FirstName = "Yan",
                            LastName = "Li",
                            DateOfBirth = DateTime.Parse("2002-09-01"),
                            Email = "abcd@hotmail.com",
                            Phone = "778-123-4567",
                            Street = "880 Granville St",
                            City = "Vancouver",
                            ZIP = "V3D1N9"
                        },
                    };
                    foreach (HandyMember s in HandyMembers)
                    {
                        context.HandyMember.Add(s);
                    }
                    context.SaveChanges();
                }
                if (!context.JobType.Any())
                {
                    context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('JobType', RESEED, 0)");
                    var JobTypes = new JobType[]
                    {
                        new JobType
                        {
                            TaskName ="Plumbing",
                            Category ="Home Repair",
                            Description ="Fix pipes and fixtures"
                        },
                        new JobType
                        {
                            TaskName ="Landscaping",
                            Category ="Garden Work",
                            Description ="Apply pesticide, plant flowers, cut weed and lawn mowing"
                        },
                        new JobType
                        {
                            TaskName ="Lawn Mowing",
                            Category ="Garden Work",
                            Description ="Cut weed and lawn mowing"
                        },
                        new JobType
                        {
                            TaskName ="Snow Shoveling",
                            Category ="Garden Work",
                            Description ="Snow removal in garden and sidewalks"
                        }
                    };
                    foreach (JobType c in JobTypes)
                    {
                        context.JobType.Add(c);
                    }
                    context.SaveChanges();
                }
                if (!context.MemberService.Any())
                {
                    context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('MemberService', RESEED, 0)");
                    var MemberServices = new MemberService[]
                    {
                        new MemberService
                        {
                            HandyMemberID = 1,
                            JobTypeID = 1,
                            Rate = 18.50m,
                            Experience = 2,
                            Certificate = false
                        },
                        new MemberService
                        {
                            HandyMemberID = 1,
                            JobTypeID = 2,
                            Rate = 25.00m,
                            Experience = 2,
                            Certificate = true
                        },
                        new MemberService
                        {
                            HandyMemberID = 1,
                            JobTypeID = 2,
                            Rate = 23.50m,
                            Experience = 2,
                            Certificate = true
                        },
                        new MemberService
                        {
                            HandyMemberID = 2,
                            JobTypeID = 4,
                            Rate = 15.00m,
                            Experience = 2,
                            Certificate = false
                        },
                        new MemberService
                        {
                            HandyMemberID = 2,
                            JobTypeID = 1,
                            Rate = 20.00m,
                            Experience = 2,
                            Certificate = true
                        },
                    };
                    foreach (MemberService e in MemberServices)
                    {
                        context.MemberService.Add(e);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
